using HTIM.Trades.Business.Helpers;
using HTIM.Trades.Business.Interfaces;
using HTIM.Trades.Model;
using HTIM.Trades.Services;

namespace HTIM.Trades.Business.Facade
{
    public class TradesFacade : ITradesFacade
    {
        private readonly ITradesService _tradeService;

        public TradesFacade(ITradesService tradeService)
        {
            _tradeService = tradeService;
        }

        public async Task<List<Trade>> GetAllTrades()
        {
            return await _tradeService.GetAllTrades();
        }

        public async Task<List<ChartInfo>> getChartInfo(string months)
        {
            return await _tradeService.getChartInfo(months);
        }

        public async Task<bool> deleteTrades(string trades, string overrides)
        {
            return await _tradeService.deleteTrades(trades, overrides);
        }

        public async Task<bool> insertTrades(string trades, string overrides)
        {
            return await _tradeService.deleteTrades(trades, overrides);
        }

        public async Task<bool> updateTrades(string trades, string overrides)
        {
            return await _tradeService.updateTrades(trades,overrides);
        }
    }
}
