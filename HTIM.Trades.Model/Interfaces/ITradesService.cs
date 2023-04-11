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
        Task<bool> updateTrades(string trades);
    }
}
