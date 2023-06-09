﻿using HTIM.Trades.Business.Helpers;
using HTIM.Trades.Business.Interfaces;
using HTIM.Trades.Model;
using HTIM.Trades.Services;
using System.Diagnostics;

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

        public async Task<bool> deleteTrades(string trades, string overrides,string user)
        {
            return await _tradeService.deleteTrades(trades, overrides,user);
        }

        public async Task<bool> insertTrades(string trades, string overrides,string user)
        {
            return await _tradeService.insertTrades(trades, overrides,user);
        }

        public async Task<bool> updateTrades(string trades, string overrides,string user)
        {
            return await _tradeService.updateTrades(trades,overrides,user);
        }

        public async Task<List<TradesAudit>> tradesToApprove(string user)
        {
            return await _tradeService.tradesToApprove(user);
        }

        public async Task<List<TradesOverrideAudit>> overridesToApprove(string user)
        {
            return await _tradeService.overridesToApprove(user);
        }

        public async Task<bool> approveTrades(string tradeIds, string approver)
        {
           return await _tradeService.approveTrades(tradeIds, approver);    
        }

        public async Task<bool> approveOverrides(string overrideIds, string approver)
        {
            return await _tradeService.approveOverrides(overrideIds, approver); 
        }
    }
}
