using HTIM.Trades.Model;
namespace HTIM.Trades.Data
{
public interface ITradesRepo
{
        Task<List<Trade>> GetAllCleanTrades();
        Task<List<TradesOverride>> GetAllOverrides();
        Task<bool> updateTrades(List<Trade> trades);
        Task<bool> updateOverrides(List<TradesOverride> overrides);
        Task<bool> deleteTrades(List<Trade> trades);
        Task<bool> deleteOverrides(List<TradesOverride> overrides);
        Task<bool> insertTrades(List<Trade> trades);
        Task<bool> insertOverrides( List<TradesOverride> overrides);

    }
}
