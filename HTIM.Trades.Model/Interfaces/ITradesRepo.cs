using HTIM.Trades.Model;
namespace HTIM.Trades.Data
{
public interface ITradesRepo
{
        Task<List<Trade>> GetAllCleanTrades();
        Task<List<TradesOverride>> GetAllOverrides();
        Task<bool> Update(List<Trade> trades, List<TradesOverride> overrides, string user);
        Task<bool> Delete(List<Trade> trades, List<TradesOverride> overrides, string user);
        Task<bool> Insert(List<Trade> trades, List<TradesOverride> overrides, string user);
        Task<bool> updateTrades(List<Trade> trades ,string user);
        Task<bool> updateOverrides(List<TradesOverride> overrides, string user);
        Task<bool> deleteTrades(List<Trade> trades, string user);
        Task<bool> deleteOverrides(List<TradesOverride> overrides, string user);
        Task<bool> insertTrades(List<Trade> trades, string user);
        Task<bool> insertOverrides( List<TradesOverride> overrides, string user);
        Task<List<TradesAudit>> tradesToApprove(string user);
        Task<List<TradesOverrideAudit>> overridesToApprove(string user);
        Task<bool> approveTrades(List<int> tradeIds, string approver);
        Task<bool> approveOverrides(List<int> overrideIds, string approver);

    }
}
