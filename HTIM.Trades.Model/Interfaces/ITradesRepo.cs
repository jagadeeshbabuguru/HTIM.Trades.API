using HTIM.Trades.Model;
namespace HTIM.Trades.Data
{
public interface ITradesRepo
{
        Task<List<Trade>> GetAllCleanTrades();
        Task<List<TradesOverride>> GetAllOverrides();
        Task<bool> updateTrades(List<Trade> trades);

    }
}
