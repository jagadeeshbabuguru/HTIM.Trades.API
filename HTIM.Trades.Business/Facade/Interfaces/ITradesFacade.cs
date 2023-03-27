using HTIM.Trades.Model;


namespace HTIM.Trades.Business.Interfaces
{
    public interface ITradesFacade
    {
        Task<List<TradesOverride>> GetAllTrades();
        Task<List<TradesOverride>> GetAllOutOfThresholdLogs();
        Task<List<TradesOverride>> GetLogsFilteredByProcessCode(string batchProcessCode);
        Task<List<TradesOverride>> GetOOTLogsFilteredByProcessCode(string batchProcessCode);
        Task<List<TradesOverride>> GetLogsFilteredByDate(string fromDate, string toDate);
        Task<List<TradesOverride>> GetOutOfThresholdLogsByDate(string fromDate, string toDate);
        Task<List<TradesOverride>> GetLogsByCodeAndDate(string processCode, string fromDate, string toDate);
        Task<List<TradesOverride>> GetOOTLogsByCodeAndDate(string processCode, string fromDate, string toDate);
        Task<List<Processes>> getProcesses(string months);
        Task<List<ChartInfo>> getChartInfo(string months);
    }
}
