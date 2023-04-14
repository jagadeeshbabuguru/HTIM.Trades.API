using System.Numerics;
using System.Runtime.CompilerServices;
using HTIM.Trades.Data;
using HTIM.Trades.Model;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace HTIM.Trades.Services
{
    public class TradesService : ITradesService
    {
        private readonly ITradesRepo _tradeRepo;

        public TradesService(ITradesRepo tradeRepo)
        {
            this._tradeRepo = tradeRepo;
        }
        public async Task<List<Trade>> GetAllTrades()
        {
            List<Trade> trades = await _tradeRepo.GetAllCleanTrades();
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

        private async Task<List<Trade>> deserializeTrades(string jsonData)
        {
            List<Trade> result = null;
            try
            {
                result = JsonSerializer.Deserialize<List<Trade>>(jsonData);
            }
            catch (Exception ex)
            {

            }

            return result;
        }
        private async Task<List<TradesOverride>> deserializeTradeOverrides(string jsonData)
        {
            List<TradesOverride> result = null;
            try
            {
                result = JsonSerializer.Deserialize<List<TradesOverride>>(jsonData);
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<bool> updateTrades(string trades,string overrides)
        {
            bool isTradeeSuccess,isOverrideSuccess = false;
            List<Trade> tradesList = await this.deserializeTrades(trades);
            List<TradesOverride> overridesList = await this.deserializeTradeOverrides(overrides);
            isTradeeSuccess = await _tradeRepo.updateTrades(tradesList);
            isOverrideSuccess = await _tradeRepo.updateOverrides(overridesList);
            return (isTradeeSuccess&&isOverrideSuccess)?true:false;
        }

        public async Task<bool> deleteTrades(string trades, string overrides)
        {
            bool isTradeeSuccess, isOverrideSuccess = false;
            List<Trade> tradesList = await this.deserializeTrades(trades.Replace("\"overrides\":{", "\"overrides\":[{").Replace("}}", "}]}"));
            List<TradesOverride> overridesList = await this.deserializeTradeOverrides(trades.Replace("\"overrides\":{", "\"overrides\":[{").Replace("}}", "}]}"));
            isTradeeSuccess = await _tradeRepo.deleteTrades(tradesList);
            isOverrideSuccess = await _tradeRepo.deleteOverrides(overridesList);
            return (isTradeeSuccess && isOverrideSuccess) ? true : false;
        }

        public async Task<bool> insertTrades(string trades, string overrides)
        {
            bool isTradeeSuccess, isOverrideSuccess = false;
            List<Trade> tradesList = await this.deserializeTrades(trades.Replace("\"overrides\":{", "\"overrides\":[{").Replace("}}", "}]}"));
            List<TradesOverride> overridesList = await this.deserializeTradeOverrides(trades.Replace("\"overrides\":{", "\"overrides\":[{").Replace("}}", "}]}"));
            isTradeeSuccess = await _tradeRepo.insertTrades(tradesList);
            isOverrideSuccess = await _tradeRepo.insertOverrides(overridesList);
            return (isTradeeSuccess && isOverrideSuccess) ? true : false;
        }
    }
}