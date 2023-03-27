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
        Task<List<TradesOverride>> GetAllTrades();
        Task<List<TradesOverride>> GetAllOutOfThresholdLogs();
        Task<List<TradesOverride>> GetLogsFilteredByProcessCode(string batchProcessCode);
        Task<List<TradesOverride>> GetOOTLogsFilteredByProcessCode(string batchProcessCode);
        Task<List<TradesOverride>> GetLogsFilteredByDate(DateTime fromDate, DateTime toDate);
        Task<List<TradesOverride>> GetOutOfThresholdLogsByDate(DateTime fromDate, DateTime toDate);
        Task<List<TradesOverride>> GetLogsByCodeAndDate(string processCode, DateTime fromDate, DateTime toDate);
        Task<List<TradesOverride>> GetOOTLogsByCodeAndDate(string processCode, DateTime fromDate, DateTime toDate);
        Task<List<Processes>> getProcesses(string months);
        Task<List<ChartInfo>> getChartInfo(string months);
    }
}
