using Microsoft.AspNetCore.Mvc;
using HTIM.Trades.Business.Interfaces;
using HTIM.Trades.Model;
using HTIM.Trades.Business.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace HTIM.Trades.Api.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    //[Authorize]
    public class TradesController : Controller
    {
        private ITradesFacade _TradesFacade;
        public TradesController(ITradesFacade TradesFacade)
        {
            this._TradesFacade = TradesFacade;
        }
        [HttpGet("getalltrades")]
        //[Authorize(Policy = "AppRights")]
        public async Task<List<Trade>> GetAllTrades()
        {
             List <Trade> result = await this._TradesFacade.GetAllTrades();
            return result;
        }
        //[HttpGet("getlogbyprocess")]
        //[Authorize(Policy = "AppRights")]
        //public async Task<List<TradeLogs>> GetLogsByProcessName(string batchProcessName)
        //{
        //    List<TradeLogs> result = await _TradesFacade.GetLogsFilteredByProcessCode(batchProcessName);
        //    return result;
        //}
        //[HttpGet("getlogbydate")]
        //[Authorize(Policy = "AppRights")]
        //public async Task<List<TradeLogs>> GetLogsByDate(string fromDate,string toDate)
        //{
        //    List<TradeLogs> result = await _TradesFacade.GetLogsFilteredByDate(fromDate, toDate);
        //    return result;
        //}
        //[HttpGet("getlogbycodeanddate")]
        //[Authorize(Policy = "AppRights")]
        //public async Task<List<TradeLogs>> GetLogsByCodeAndDate(string batchProcessName, string fromDate, string toDate)
        //{
        //    List<TradeLogs> result = await _TradesFacade.GetLogsByCodeAndDate(batchProcessName,fromDate, toDate);
        //    return result;
        //}
        //[HttpGet("getoutofthresholdlogs")]
        //[Authorize(Policy = "AppRights")]
        //public async Task<List<TradeLogs>> GetAllOutOfThresholdLogs()
        //{
        //    List<TradeLogs> result = await _TradesFacade.GetAllOutOfThresholdLogs();
        //    return result;
        //}

        //[HttpGet("getoutofthresholdlogsbyprocess")]
        //[Authorize(Policy = "AppRights")]
        //public async Task<List<TradeLogs>> GetAllOutOfThresholdLogsByProcess(string batchProcessName)
        //{
        //    List<TradeLogs> result = await _TradesFacade.GetOOTLogsFilteredByProcessCode(batchProcessName);
        //    return result;
        //}

        //[HttpGet("getoutofthresholdbydate")]
        //[Authorize(Policy = "AppRights")]
        //public async Task<List<TradeLogs>> GetOutOfThresholdLogsByDate(string fromDate, string toDate)
        //{
        //    List<TradeLogs> result = await _TradesFacade.GetOutOfThresholdLogsByDate(fromDate,toDate);
        //    return result;
        //}
        //[HttpGet("getootlogsbycodeanddate")]
        //[Authorize(Policy = "AppRights")]
        //public async Task<List<TradeLogs>> GetOOTLogsCodeByDate(string batchProcessName, string fromDate, string toDate)
        //{
        //    List<TradeLogs> result = await _TradesFacade.GetOOTLogsByCodeAndDate(batchProcessName,fromDate, toDate);
        //    return result;
        //}

        //[HttpGet("getprocessdatacount")]
        //[Authorize(Policy = "AppRights")]
        //public async Task<List<Processes>> GetProcessData(string months)
        //{
        //    List<Processes> result = await _TradesFacade.getProcesses(months);
        //    return result;
        //}

        //[HttpGet("getChartInfo")]
        //[Authorize(Policy = "AppRights")]
        //public async Task<List<ChartInfo>> GetChartInfo(string months)
        //{
        //    List<ChartInfo> result = await _TradesFacade.getChartInfo(months);
        //    return result;
        //}
    }
}
