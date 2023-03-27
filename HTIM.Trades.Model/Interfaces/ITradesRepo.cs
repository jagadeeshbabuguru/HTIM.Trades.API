using HTIM.Trades.Model;
namespace HTIM.Trades.Data
{
public interface ITradesRepo
{
        Task<List<TradesOverride>> GetLogsFilteredByProcessCode(string processCode);
        Task<List<TradesOverride>> GetOOTLogsFilteredByProcessCode(string batchProcessCode);
        Task<List<TradesOverride>> GetLogsFilteredByDate(DateTime fromDate,DateTime toDate);
        Task<List<TradesOverride>> GetOutOfThresholdLogsByDate(DateTime fromDate,DateTime toDate);
        Task<List<TradesOverride>> GetAllTrades();
        Task<List<TradesOverride>> GetAllOutOfThresholdLogs();
        Task<List<TradesOverride>> GetLogsByCodeAndDate(string processCode,DateTime fromDate,DateTime toDate);
        Task<List<TradesOverride>> GetOOTLogsByCodeAndDate(string processCode, DateTime fromDate, DateTime toDate);
        Task<List<Processes>> getProcesses(string months);
    }
}
