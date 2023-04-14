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
    [Authorize]
    public class TradesController : Controller
    {
        private ITradesFacade _TradesFacade;
        public TradesController(ITradesFacade TradesFacade)
        {
            this._TradesFacade = TradesFacade;
        }
        [HttpGet("getalltrades")]
        [Authorize(Policy = "AppRights")]
        public async Task<List<Trade>> GetAllTrades()
        {
             List <Trade> result = await this._TradesFacade.GetAllTrades();
            return result;
        }

        [HttpGet("updatetrade")]
        [Authorize(Policy = "AppRights")]
        public async Task<bool> updatetrade(string tradesToUpdate,string overridesToUpdate)
        {
            bool result = await this._TradesFacade.updateTrades(tradesToUpdate,overridesToUpdate);
            return result;
        }

        [HttpGet("deletetrade")]
        [Authorize(Policy = "AppRights")]
        public async Task<bool> deletetrade(string tradesToUpdate, string overridesToUpdate)
        {
            bool result = await this._TradesFacade.deleteTrades(tradesToUpdate, overridesToUpdate);
            return result;
        }
        [HttpGet("createtrade")]
        [Authorize(Policy = "AppRights")]
        public async Task<bool> createtrade(string tradesToUpdate, string overridesToUpdate)
        {
            bool result = await this._TradesFacade.insertTrades(tradesToUpdate, overridesToUpdate);
            return result;
        }
    }
}
