using Dapper;
using System.Data;
using System.Data.SqlClient;
using HTIM.Trades.Model;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace HTIM.Trades.Data
{

    public class TradesRepo : ITradesRepo
    {
        private readonly IDbConnection _connection;

        public TradesRepo(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<List<TradesOverride>> GetAllOutOfThresholdLogs()
        {
            IEnumerable<TradesOverride> processLogs = await GetTableValues<TradesOverride>("AssetFileWatcher.GetLogs", false, false, true, null, null, null);
            return processLogs.ToList();
        }

        public async Task<List<Trade>> GetAllCleanTrades()
        {
            IEnumerable<Trade> cleanTrades = await GetTableValuesBySp<Trade>("TradesViewer.GetAllCleanTrades");
            IEnumerable<TradesOverride> overrides = await GetTableValuesBySp<TradesOverride>("TradesViewer.GetAllTradeOverrides");
            cleanTrades.ToList().ForEach(trade =>
            {
                if (trade.overrides == null)
                    trade.overrides =  new List<TradesOverride>();
                trade.overrides.AddRange(overrides.Where(x => x.tradesOverrideID == trade.rowID));
            });
            return cleanTrades.ToList();
        }

        public async Task<List<TradesOverride>> GetAllOverrides()
        {
           
            return new List<TradesOverride>();
        }


        public async Task<List<TradesOverride>> GetOutOfThresholdLogsByDate(DateTime fromDate, DateTime toDate)
        {
            IEnumerable<TradesOverride> processLogs = await GetTableValues<TradesOverride>("AssetFileWatcher.GetLogs", false, true, true, null, fromDate, toDate);
            return processLogs.ToList();
        }

        public async Task<List<TradesOverride>> GetLogsFilteredByDate(DateTime fromDate, DateTime toDate)
        {
            IEnumerable<TradesOverride> processLogs = await GetTableValues<TradesOverride>("AssetFileWatcher.GetLogs", false, true, false, null, fromDate, toDate);
            return processLogs.ToList();
        }

        public async Task<List<TradesOverride>> GetLogsFilteredByProcessCode(string processCode)
        {
            IEnumerable<TradesOverride> processLogs = await GetTableValues<TradesOverride>("AssetFileWatcher.GetLogs", true, false, false, processCode, null, null);
            return processLogs.ToList();
        }

        public async Task<List<TradesOverride>> GetOOTLogsFilteredByProcessCode(string batchProcessCode)
        {
            IEnumerable<TradesOverride> processLogs = await GetTableValues<TradesOverride>("AssetFileWatcher.GetLogs", true, false, true, batchProcessCode, null, null);
            return processLogs.ToList();
        }

        public async Task<List<TradesOverride>> GetLogsByCodeAndDate(string processCode, DateTime fromDate, DateTime toDate)
        {
            IEnumerable<TradesOverride> processLogs = await GetTableValues<TradesOverride>("AssetFileWatcher.GetLogs", true, true, false, processCode, fromDate, toDate);
            return processLogs.ToList();
        }

        public async Task<List<TradesOverride>> GetOOTLogsByCodeAndDate(string processCode, DateTime fromDate, DateTime toDate)
        {
            IEnumerable<TradesOverride> processLogs = await GetTableValues<TradesOverride>("AssetFileWatcher.GetLogs", true, true, true, processCode, fromDate, toDate);
            return processLogs.ToList();
        }

        public async Task<List<Processes>> getProcesses(string months)
        {
            IEnumerable<Processes> stats = await GetTableValuesBySp<Processes>("AssetFileWatcher.GetLogsSummary");
            return stats.ToList();
        }

        //private async Task<IEnumerable<T>> GetTableValues<T>(string spName, bool isByProcessCode,bool isByDate,bool isOutOfThresholdLogs, string? processCode,DateTime? fromDate,DateTime? toDate)
        //{
        //    IEnumerable<T> returnVal = new List<T>();
        //    var dataTable = new DataTable();
        //    try
        //    {
        //        using (_connection)
        //        {
        //            _connection.Open();
        //            returnVal = await _connection.QueryAsync<T>(spName, new { isByProcessCode, isByDate, isOutOfThresholdLogs,processCode,fromDate,toDate }, commandType: CommandType.StoredProcedure);
        //            _connection.Close();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    return returnVal;
        //}

         private async Task<IEnumerable<T>> GetTableValues<T>(string spName, bool isByProcessCode,bool isByDate,bool isOutOfThresholdLogs, string? processCode,DateTime? fromDate,DateTime? toDate)
        {
            IEnumerable<T> returnVal = new List<T>();
            var dataTable = new DataTable();
            try
            {
                using (_connection)
                {
                    _connection.Open();
                    returnVal = await _connection.QueryAsync<T>(spName,commandType: CommandType.StoredProcedure);
                    _connection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return returnVal;
        }

        private async Task<IEnumerable<T>> GetTableValuesBySp<T>(string spName)
        {
            IEnumerable<T> returnVal = new List<T>();
            var dataTable = new DataTable();
            try
            {
                    _connection.Open();
                    returnVal = await _connection.QueryAsync<T>(spName, commandType: CommandType.StoredProcedure);
                    _connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return returnVal;
        }

        public Task<bool> updateTrades(List<Trade> trades)
        {
            throw new NotImplementedException();
        }
    }
}
