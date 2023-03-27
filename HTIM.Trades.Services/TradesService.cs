using System.Numerics;
using System.Runtime.CompilerServices;
using HTIM.Trades.Data;
using HTIM.Trades.Model;

namespace HTIM.Trades.Services
{
    public class TradesService : ITradesService
    {
        private readonly ITradesRepo _blogRepo;

        public TradesService(ITradesRepo batchRepo)
        {
            this._blogRepo = batchRepo;
        }
        public async Task<List<TradesOverride>> GetAllTrades()
        {
            return await _blogRepo.GetAllTrades(); 
        }

        public async Task<List<TradesOverride>> GetAllOutOfThresholdLogs()
        {
            return await _blogRepo.GetAllOutOfThresholdLogs();
        }

        public async Task<List<TradesOverride>> GetOutOfThresholdLogsByDate(DateTime fromDate, DateTime toDate)
        {
            return await _blogRepo.GetOutOfThresholdLogsByDate(fromDate,toDate);
        }

        public async Task<List<TradesOverride>> GetLogsFilteredByDate(DateTime fromDate, DateTime toDate)
        {
            return await _blogRepo.GetLogsFilteredByDate(fromDate,toDate);
        }

        public async Task<List<TradesOverride>> GetLogsFilteredByProcessCode(string batchProcessCode)
        {
            return await _blogRepo.GetLogsFilteredByProcessCode(batchProcessCode);
        }

        public async Task<List<TradesOverride>> GetOOTLogsFilteredByProcessCode(string batchProcessCode)
        {
            return await _blogRepo.GetOOTLogsFilteredByProcessCode(batchProcessCode);
        }

        public async Task<List<TradesOverride>> GetLogsByCodeAndDate(string processCode, DateTime fromDate, DateTime toDate)
        {
            return await _blogRepo.GetLogsByCodeAndDate(processCode, fromDate,toDate);
        }

        public async Task<List<TradesOverride>> GetOOTLogsByCodeAndDate(string processCode, DateTime fromDate, DateTime toDate)
        {
            return await _blogRepo.GetOOTLogsByCodeAndDate(processCode, fromDate,toDate);
        }

        public async Task<List<Processes>> getProcesses(string months)
        {
            return await _blogRepo.getProcesses(months);
        }

        public async Task<List<ChartInfo>> getChartInfo(string months)
        {
            List<ChartInfo> chartInfo = new List<ChartInfo>();
            int totalErrors = 0, totalWarnings = 0, totalSuccess = 0, totalValues = 0;
            try
            {
                List<Processes> process = await _blogRepo.getProcesses(months);

                if (process != null || process.Count() > 0)
                {
                    foreach (var v in process)
                    {
                        totalErrors += v.errorCount;
                        totalWarnings += v.warningsCount;
                        totalSuccess += v.successCount;
                    }

                    totalValues = totalErrors + totalSuccess + totalWarnings;
                    int share = (100 * totalSuccess) / totalValues;
                    chartInfo.Add(new ChartInfo()
                    {
                        share = (int)Math.Round((double)(100 * totalErrors) / totalValues),
                        kind = "Errors: " + totalErrors
                    });
                    
                    chartInfo.Add(new ChartInfo()
                    {
                        
                        share = (int)Math.Round((double)(100 * totalWarnings) / totalValues),
                        kind = "Warnings: " + totalWarnings
                    });

                    chartInfo.Add(new ChartInfo()
                    {

                        share = (int)Math.Round((double)(100 * totalSuccess) / totalValues),
                        kind = "Success: " + totalSuccess
                    });

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return chartInfo;
        }
    }
}