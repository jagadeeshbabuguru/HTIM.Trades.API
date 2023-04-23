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
           
            return trades;
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
        private async Task<List<int>> deserializeIds(string jsonData)
        {
            List<int> result = null;
            try
            {
                result = JsonSerializer.Deserialize<List<int>>(jsonData);
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<bool> updateTrades(string trades,string overrides,string user)
        {
            List<Trade> tradesList = await this.deserializeTrades(trades.Replace("\"overrides\":{", "\"overrides\":[{").Replace("}}", "}]}"));
            List<TradesOverride> overridesList = await this.deserializeTradeOverrides(overrides);        
            return await _tradeRepo.Update(tradesList,overridesList,user);
        }

        public async Task<bool> deleteTrades(string trades, string overrides,string user)
        {
            List<Trade> tradesList = await this.deserializeTrades(trades);
            List<TradesOverride> overridesList = await this.deserializeTradeOverrides(overrides);
            return await _tradeRepo.Delete(tradesList, overridesList,user);
        }

        public async Task<bool> insertTrades(string trades, string overrides, string user)
        {
            List<Trade> tradesList = await this.deserializeTrades(trades.Replace("\"overrides\":{", "\"overrides\":[{").Replace("}}", "}]}"));
            List<TradesOverride> overridesList = await this.deserializeTradeOverrides(overrides);
            return await _tradeRepo.Insert(tradesList, overridesList,user);
        }

        public async Task<List<TradesAudit>> tradesToApprove(string user)
        {
            return await _tradeRepo.tradesToApprove(user);
        }

        public async Task<List<TradesOverrideAudit>> overridesToApprove(string user)
        {
            return await _tradeRepo.overridesToApprove(user);
        }

        public async Task<bool> approveTrades(string tradeIds, string approver)
        {
            return await _tradeRepo.approveTrades(await deserializeIds(tradeIds),approver);
        }

        public async Task<bool> approveOverrides(string overrideIds, string approver)
        {
            return await _tradeRepo.approveOverrides(await deserializeIds(overrideIds), approver);
        }

        public Task<List<ChartInfo>> getChartInfo(string months)
        {
            throw new NotImplementedException();
        }
    }
}