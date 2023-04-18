using HTIM.Trades.Model;


namespace HTIM.Trades.Business.Interfaces
{
    public interface ITradesFacade
    {
        Task<List<Trade>> GetAllTrades();
        //Task<List<TradesOverride>> GetAllCleanTrades();
        Task<List<ChartInfo>> getChartInfo(string months);

        Task<bool> updateTrades(string trades,string overrides);
        Task<bool> deleteTrades(string trades, string overrides);
        Task<bool> insertTrades(string trades, string overrides);

        Task<List<TradesAudit>> tradesToApprove();
        Task<List<TradesOverrideAudit>> overridesToApprove();
    }
}
