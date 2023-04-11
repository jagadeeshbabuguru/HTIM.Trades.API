using HTIM.Trades.Model;


namespace HTIM.Trades.Business.Interfaces
{
    public interface ITradesFacade
    {
        Task<List<Trade>> GetAllTrades();
        //Task<List<TradesOverride>> GetAllCleanTrades();
        Task<List<ChartInfo>> getChartInfo(string months);

        Task<bool> updateTrades(string trades);
    }
}
