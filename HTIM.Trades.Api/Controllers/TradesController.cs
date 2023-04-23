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
            bool result = await this._TradesFacade.updateTrades(tradesToUpdate,overridesToUpdate, User.Identities.FirstOrDefault().Name.Split('@')[0].Replace('.', ' '));
            return result;
        }

        [HttpGet("deletetrade")]
        [Authorize(Policy = "AppRights")]
        public async Task<bool> deletetrade(string tradesTodelete, string overridesTodelete)
        {
            bool result = await this._TradesFacade.deleteTrades(tradesTodelete, overridesTodelete, User.Identities.FirstOrDefault().Name.Split('@')[0].Replace('.', ' '));
            return result;
        }
        [HttpGet("createtrade")]
        [Authorize(Policy = "AppRights")]
        public async Task<bool> createtrade(string tradesToInsert, string overridesToInsert)
        {
            bool result = await this._TradesFacade.insertTrades(tradesToInsert, overridesToInsert, User.Identities.FirstOrDefault().Name.Split('@')[0].Replace('.', ' '));
            return result;
        }
        [HttpGet("tradestoapprove")]
        [Authorize(Policy = "AppRights")]
        public async Task<List<TradesAudit>> tradestoapprove()
        {
            return await this._TradesFacade.tradesToApprove(User.Identities.FirstOrDefault().Name.Split('@')[0].Replace('.', ' '));
        }
        [HttpGet("overridestoapprove")]
        [Authorize(Policy = "AppRights")]
        public async Task<List<TradesOverrideAudit>> overridestoapprove()
        {
            return await this._TradesFacade.overridesToApprove(User.Identities.FirstOrDefault().Name.Split('@')[0].Replace('.', ' '));
        }
        [HttpGet("approvetrades")]
        [Authorize(Policy = "AppRights")]
        public async Task<bool> approvetrades(string tradesIds)
        {
            return await this._TradesFacade.approveTrades(tradesIds, User.Identities.FirstOrDefault().Name.Split('@')[0].Replace('.', ' '));
        }
        [HttpGet("approveoverrides")]
        [Authorize(Policy = "AppRights")]
        public async Task<bool> approveoverrides(string overrideIds)
        {
            return await this._TradesFacade.approveOverrides(overrideIds, User.Identities.FirstOrDefault().Name.Split('@')[0].Replace('.', ' '));
        } 
    }
}
