using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTIM.Trades.Model;

namespace HTIM.Trades.Services
{
    public interface ITradesService
    {
        Task<List<Trade>> GetAllTrades();
        Task<List<ChartInfo>> getChartInfo(string months);
        Task<bool> updateTrades(string trades, string overrides, string user);
        Task<bool> deleteTrades(string trades, string overrides, string user);
        Task<bool> insertTrades(string trades, string overrides, string user);
        Task<List<TradesAudit>> tradesToApprove(string user);
        Task<List<TradesOverrideAudit>> overridesToApprove(string user);
        Task<bool> approveTrades(string tradeIds, string approver);
        Task<bool> approveOverrides(string overrideIds, string approver);
    }
}
