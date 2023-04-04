using System.Numerics;
using System.Runtime.CompilerServices;
using HTIM.Trades.Data;
using HTIM.Trades.Model;

namespace HTIM.Trades.Services
{
    public class TradesService : ITradesService
    {
        private readonly ITradesRepo _blogRepo;

        public TradesService(ITradesRepo batchRepo)
        {
            this._blogRepo = batchRepo;
        }
        public async Task<List<Trade>> GetAllTrades()
        {
            List<Trade> trades = await _blogRepo.GetAllCleanTrades();
            //List<TradesOverride> tradeOverrides = await _blogRepo.GetAllOverrides();
           
            return trades;
        }

        public async Task<List<ChartInfo>> getChartInfo(string months)
        {
            //List<ChartInfo> chartInfo = new List<ChartInfo>();
            //int totalErrors = 0, totalWarnings = 0, totalSuccess = 0, totalValues = 0;
            try
            {
            //    List<Processes> process = await _blogRepo.getProcesses(months);

            //    if (process != null || process.Count() > 0)
            //    {
            //        foreach (var v in process)
            //        {
            //            totalErrors += v.errorCount;
            //            totalWarnings += v.warningsCount;
            //            totalSuccess += v.successCount;
            //        }

            //        totalValues = totalErrors + totalSuccess + totalWarnings;
            //        int share = (100 * totalSuccess) / totalValues;
            //        chartInfo.Add(new ChartInfo()
            //        {
            //            share = (int)Math.Round((double)(100 * totalErrors) / totalValues),
            //            kind = "Errors: " + totalErrors
            //        });
                    
            //        chartInfo.Add(new ChartInfo()
            //        {
                        
            //            share = (int)Math.Round((double)(100 * totalWarnings) / totalValues),
            //            kind = "Warnings: " + totalWarnings
            //        });

            //        chartInfo.Add(new ChartInfo()
            //        {

            //            share = (int)Math.Round((double)(100 * totalSuccess) / totalValues),
            //            kind = "Success: " + totalSuccess
            //        });

            //    }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new List<ChartInfo>();
        }
    }
}