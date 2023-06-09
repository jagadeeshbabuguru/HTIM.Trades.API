﻿using Dapper;
using System.Data;
using System.Data.SqlClient;
using HTIM.Trades.Model;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace HTIM.Trades.Data
{

    public class TradesRepo : ITradesRepo
    {
        private readonly IDbConnection _connection;

        public TradesRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Trade>> GetAllCleanTrades()
        {
            IEnumerable<Trade> cleanTrades = await GetTableValuesBySp<Trade>("TradesViewer.GetAllCleanTrades");
            IEnumerable<TradesOverride> overrides = await GetTableValuesBySp<TradesOverride>("TradesViewer.GetAllTradeOverrides");
            cleanTrades.ToList().ForEach(trade =>
            {
                if (trade.overrides == null)
                    trade.overrides =  new List<TradesOverride>();
                trade.overrides.AddRange(overrides.Where(x => x.tradeID == trade.rowID));
            });
            return cleanTrades.ToList();
        }

        public async Task<List<TradesOverride>> GetAllOverrides()
        {
           
            return new List<TradesOverride>();
        }

         private async Task<IEnumerable<T>> GetTableValues<T>(string spName, bool isByProcessCode,bool isByDate,bool isOutOfThresholdLogs, string? processCode,DateTime? fromDate,DateTime? toDate)
        {
            IEnumerable<T> returnVal = new List<T>();
            var dataTable = new DataTable();
            try
            {
                using (_connection)
                {
                    _connection.Open();
                    returnVal = await _connection.QueryAsync<T>(spName,commandType: CommandType.StoredProcedure);
                    _connection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return returnVal;
        }

        private async Task<IEnumerable<T>> GetTableValuesBySp<T>(string spName)
        {
            IEnumerable<T> returnVal = new List<T>();
            var dataTable = new DataTable();
            try
            {
                    _connection.Open();
                    returnVal = await _connection.QueryAsync<T>(spName, commandType: CommandType.StoredProcedure);
                    _connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return returnVal;
        }
        private async Task<IEnumerable<T>> GetTableValuesBySpWithParams<T>(string spName,string user)
        {
            IEnumerable<T> returnVal = new List<T>();
            var dataTable = new DataTable();
            try
            {
                _connection.Open();
                returnVal = await _connection.QueryAsync<T>(spName, new { Approver = user }, commandType: CommandType.StoredProcedure);
                _connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return returnVal;
        }

        public async Task<bool> Update(List<Trade> trades,List<TradesOverride> overrides, string user)
        {
            bool isTradeeSuccess = false, isOverrideSuccess = false;
            if (trades.Count() > 0)
                isTradeeSuccess = await this.updateTrades(trades,user);
            else
                isTradeeSuccess = true;
            if (overrides.Count() > 0)
                isOverrideSuccess = await this.updateOverrides(overrides,user);
            else
                isOverrideSuccess = true;

            return (isTradeeSuccess && isOverrideSuccess) ? true : false;
        }

        public async Task<bool> Delete(List<Trade> trades, List<TradesOverride> overrides, string user  )
        {
            bool isTradeeSuccess = false, isOverrideSuccess = false;
            if (trades.Count() > 0)
                isTradeeSuccess = await this.deleteTrades(trades, user);
            else
                isTradeeSuccess = true;
            if (overrides.Count() > 0)
                isOverrideSuccess = await this.deleteOverrides(overrides, user);
            else
                isOverrideSuccess = true;

            return (isTradeeSuccess && isOverrideSuccess) ? true : false;
        }

        public async Task<bool> Insert(List<Trade> trades, List<TradesOverride> overrides, string user)
        {
            bool isTradeeSuccess = false, isOverrideSuccess = false;
            if (trades.Count() > 0)
                isTradeeSuccess = await this.insertTrades(trades, user);
            else
                isTradeeSuccess = true;
            if (overrides.Count() > 0)
                isOverrideSuccess = await this.insertOverrides(overrides, user);
            else
                isOverrideSuccess = true;

            return (isTradeeSuccess && isOverrideSuccess) ? true : false;
        }

        public async Task<bool> updateTrades(List<Trade> trades,string user)
        {
            int returnVal = 0;
            Boolean successFlag = true;
            int flag = 1;
            string Change_id = "Trades Viewer API";
            try
            {
                    _connection.Open();
                    foreach (Trade trade in trades)
                    {
                        returnVal = await _connection.ExecuteScalarAsync<int>("TradesViewer.InsertTrade", new
                        {
                            trade.rowID,
                            trade.bcusip,
                            trade.fundNumber,
                            trade.invNumber,
                            trade.tradeNumber,
                            trade.tradeVersion,
                            trade.aladdinPort,
                            trade.tranType,
                            trade.tranSource,
                            trade.tradeEntry,
                            trade.tradeEffectiveDate,
                            trade.tradeDate,
                            trade.settleDate,
                            trade.brokerName,
                            trade.gaapBookValue,
                            trade.gaapBookYield,
                            trade.gaapBookPrice,
                            trade.statBookValue,
                            trade.statBookYield,
                            trade.statBookPrice,
                            trade.marketValue,
                            trade.accruedInterest,
                            trade.totalMarketValue,
                            trade.originalFace,
                            trade.tradePrice,
                            trade.tradePrincipal,
                            trade.currentFace,
                            trade.htimid,
                            trade.majorClass,
                            trade.subClass,
                            trade.couponType,
                            trade.secDesc,
                            trade.coupon,
                            trade.couponFrequency,
                            trade.currency,
                            trade.maturityDate,
                            trade.priceStyle,
                            trade.securityType,
                            trade.securityTicker,
                            trade.isin,
                            trade.sedol,
                            trade.moodysRating,
                            trade.moodysRatingDate,
                            trade.spRating,
                            trade.spRatingDate,
                            trade.fitchRating,
                            trade.fitchRatingDate,
                            trade.dbrsRating,
                            trade.dbrsRatingDate,
                            trade.naicRating,
                            trade.naicRatingDate,
                            trade.htimEffectiveRating,
                            trade.tradeConvexity,
                            trade.tradeYield,
                            trade.tradeYTC,
                            trade.tradeDuration,
                            trade.tradeSpread,
                            trade.tradeWAL,
                            trade.tradeExcluded,
                            trade.tradeCancelled,
                            trade.loadDate,
                            trade.deleteDate,
                            trade.modifiedDate,
                            statusCd = 1,
                            IsApproved = false,
                            IsUpdated = true,
                            IsDeleted = false,
                            EnteredBy = user,
                            flag = 2

                        }, commandType: CommandType.StoredProcedure) ;
                        if (returnVal != 0)
                            successFlag = false;
                        if (!successFlag)
                            break;
                    }
                    _connection.Close();
            }
            catch (SqlException ex)
            {
                successFlag = false;
            }
            return successFlag;
        }
       

        public async Task<bool> deleteTrades(List<Trade> trades, string user)
        {
            int returnVal = 0;
            Boolean successFlag = true;
            int flag = 1;
            string Change_id = "Trades Viewer API";
            try
            {
                    _connection.Open();
                    foreach (Trade trade in trades)
                    {
                        returnVal =await _connection.ExecuteScalarAsync<int>("TradesViewer.InsertTrade", new
                        {
                            trade.rowID,
                            trade.bcusip,
                            trade.fundNumber,
                            trade.invNumber,
                            trade.tradeNumber,
                            trade.tradeVersion,
                            trade.aladdinPort,
                            trade.tranType,
                            trade.tranSource,
                            trade.tradeEntry,
                            trade.tradeEffectiveDate,
                            trade.tradeDate,
                            trade.settleDate,
                            trade.brokerName,
                            trade.gaapBookValue,
                            trade.gaapBookYield,
                            trade.gaapBookPrice,
                            trade.statBookValue,
                            trade.statBookYield,
                            trade.statBookPrice,
                            trade.marketValue,
                            trade.accruedInterest,
                            trade.totalMarketValue,
                            trade.originalFace,
                            trade.tradePrice,
                            trade.tradePrincipal,
                            trade.currentFace,
                            trade.htimid,
                            trade.majorClass,
                            trade.subClass,
                            trade.couponType,
                            trade.secDesc,
                            trade.coupon,
                            trade.couponFrequency,
                            trade.currency,
                            trade.maturityDate,
                            trade.priceStyle,
                            trade.securityType,
                            trade.securityTicker,
                            trade.isin,
                            trade.sedol,
                            trade.moodysRating,
                            trade.moodysRatingDate,
                            trade.spRating,
                            trade.spRatingDate,
                            trade.fitchRating,
                            trade.fitchRatingDate,
                            trade.dbrsRating,
                            trade.dbrsRatingDate,
                            trade.naicRating,
                            trade.naicRatingDate,
                            trade.htimEffectiveRating,
                            trade.tradeConvexity,
                            trade.tradeYield,
                            trade.tradeYTC,
                            trade.tradeDuration,
                            trade.tradeSpread,
                            trade.tradeWAL,
                            trade.tradeExcluded,
                            trade.tradeCancelled,
                            trade.loadDate,
                            trade.deleteDate,
                            trade.modifiedDate,
                            statusCd = 1,
                            IsApproved = false,
                            IsUpdated = false,
                            IsDeleted = true,
                            EnteredBy=user,
                            flag = 3

                        }, commandType: CommandType.StoredProcedure);
                        if (returnVal != 0)
                            successFlag = false;
                        if (!successFlag)
                            break;
                    }
                    _connection.Close();
            }
            catch (SqlException ex)
            {
                successFlag = false;
            }
            return successFlag;
        }
        public async Task<bool> insertTrades(List<Trade> trades, string user)
        {
            int returnVal = 0;
            Boolean successFlag = true;
            int flag = 1;
            string Change_id = "Trades Viewer API";
            try
            {
                    _connection.Open();
                    foreach (Trade trade in trades)
                    {
                        returnVal = await _connection.ExecuteScalarAsync<int>("TradesViewer.InsertTrade", new
                        {
                            trade.bcusip,
                            trade.fundNumber,
                            trade.invNumber,
                            trade.tradeNumber,
                            trade.tradeVersion,
                            trade.aladdinPort,
                            trade.tranType,
                            trade.tranSource,
                            trade.tradeEntry,
                            trade.tradeEffectiveDate,
                            trade.tradeDate,
                            trade.settleDate,
                            trade.brokerName,
                            trade.gaapBookValue,
                            trade.gaapBookYield,
                            trade.gaapBookPrice,
                            trade.statBookValue,
                            trade.statBookYield,
                            trade.statBookPrice,
                            trade.marketValue,
                            trade.accruedInterest,
                            trade.totalMarketValue,
                            trade.originalFace,
                            trade.tradePrice,
                            trade.tradePrincipal,
                            trade.currentFace,
                            trade.htimid,
                            trade.majorClass,
                            trade.subClass,
                            trade.couponType,
                            trade.secDesc,
                            trade.coupon,
                            trade.couponFrequency,
                            trade.currency,
                            trade.maturityDate,
                            trade.priceStyle,
                            trade.securityType,
                            trade.securityTicker,
                            trade.isin,
                            trade.sedol,
                            trade.moodysRating,
                            trade.moodysRatingDate,
                            trade.spRating,
                            trade.spRatingDate,
                            trade.fitchRating,
                            trade.fitchRatingDate,
                            trade.dbrsRating,
                            trade.dbrsRatingDate,
                            trade.naicRating,
                            trade.naicRatingDate,
                            trade.htimEffectiveRating,
                            trade.tradeConvexity,
                            trade.tradeYield,
                            trade.tradeYTC,
                            trade.tradeDuration,
                            trade.tradeSpread,
                            trade.tradeWAL,
                            trade.tradeExcluded,
                            trade.tradeCancelled,
                            trade.loadDate,
                            trade.deleteDate,
                            trade.modifiedDate,
                            statusCd=1,
                            IsApproved=false,
                            IsUpdated=false,
                            IsDeleted=false,
                            EnteredBy = user,
                            flag =1

                        }, commandType: CommandType.StoredProcedure);
                        if (returnVal != 0)
                            successFlag = false;
                        if (!successFlag)
                            break;
                    }
                    _connection.Close();
            }
            catch (SqlException ex)
            {
                successFlag = false;
            }
            return successFlag;
        }

        public async Task<bool> insertOverrides(List<TradesOverride> overrides, string user)
        {
            int returnVal = 0;
            Boolean successFlag = true;
            int flag = 1;
            string Change_id = "Trades Viewer API";
            try
            {
                    _connection.Open();
                    foreach (TradesOverride troverrides in overrides)
                    {
                        returnVal = await _connection.ExecuteScalarAsync<int>("TradesViewer.OverridesCRUD", new
                        {
                            troverrides.tradeID,
                            troverrides.tradeEffectiveDate,
                            troverrides.gaapBookValue,
                            troverrides.gaapBookYield,
                            troverrides.gaapBookPrice,
                            troverrides.statBookValue,
                            troverrides.statBookYield,
                            troverrides.statBookPrice,
                            troverrides.tradePrice,
                            troverrides.marketValue,
                            troverrides.totalMarketValue,
                            troverrides.primarySecurityID,
                            troverrides.majorClass,
                            troverrides.subClass,
                            troverrides.securityDescription,
                            troverrides.naicRating,
                            troverrides.htimEffectiveRating,
                            troverrides.tradeConvexity,
                            troverrides.tradeYield,
                            troverrides.tradeYTC,
                            troverrides.tradeDuration,
                            troverrides.tradeSpread,
                            troverrides.tradeWAL,
                            troverrides.tradeExcluded,
                            troverrides.createDate,
                            troverrides.deleteDate,
                            troverrides.tradeVersion,
                            StatusCd=1,
                            IsApproved=false,
                            IsUpdated=false,
                            IsDeleted=false,
                            EnteredBy = user,
                            flag = 1

                        }, commandType: CommandType.StoredProcedure);
                        if (returnVal != 0)
                            successFlag = false;
                        if (!successFlag)
                            break;
                    }
                    _connection.Close();
            }
            catch (SqlException ex)
            {
                successFlag = false;
            }
            return successFlag;
        }
        public async Task<bool> updateOverrides(List<TradesOverride> overrides, string user)
        {
            int returnVal = 0;
            Boolean successFlag = true;
            int flag = 1;
            string Change_id = "Trades Viewer API";
            try
            {
                    _connection.Open();
                    foreach (TradesOverride troverrides in overrides)
                    {
                        returnVal = await _connection.ExecuteScalarAsync<int>("TradesViewer.OverridesCRUD", new
                        {
                            troverrides.tradesOverrideID,
                            troverrides.tradeID,
                            troverrides.tradeEffectiveDate,
                            troverrides.gaapBookValue,
                            troverrides.gaapBookYield,
                            troverrides.gaapBookPrice,
                            troverrides.statBookValue,
                            troverrides.statBookYield,
                            troverrides.statBookPrice,
                            troverrides.tradePrice,
                            troverrides.marketValue,
                            troverrides.totalMarketValue,
                            troverrides.primarySecurityID,
                            troverrides.majorClass,
                            troverrides.subClass,
                            troverrides.securityDescription,
                            troverrides.naicRating,
                            troverrides.htimEffectiveRating,
                            troverrides.tradeConvexity,
                            troverrides.tradeYield,
                            troverrides.tradeYTC,
                            troverrides.tradeDuration,
                            troverrides.tradeSpread,
                            troverrides.tradeWAL,
                            troverrides.tradeExcluded,
                            troverrides.createDate,
                            troverrides.deleteDate,
                            troverrides.tradeVersion,
                            StatusCd = 1,
                            IsApproved = false,
                            IsUpdated = true,
                            IsDeleted = false,
                            EnteredBy = user,
                            flag = 2

                        }, commandType: CommandType.StoredProcedure);
                        if (returnVal != 0)
                            successFlag = false;
                        if (!successFlag)
                            break;
                    }
                    _connection.Close();
            }
            catch (SqlException ex)
            {
                successFlag = false;
            }
            return successFlag;
        }
        public async Task<bool> deleteOverrides(List<TradesOverride> overrides, string user)
        {
            int returnVal = 0;
            Boolean successFlag = true;
            int flag = 1;
            string Change_id = "Trades Viewer API";
            try
            {
                    _connection.Open();
                    foreach (TradesOverride troverrides in overrides)
                    {
                        returnVal = await _connection.ExecuteScalarAsync<int>("TradesViewer.OverridesCRUD", new
                        {
                            troverrides.tradesOverrideID,
                            troverrides.tradeID,
                            troverrides.tradeEffectiveDate,
                            troverrides.gaapBookValue,
                            troverrides.gaapBookYield,
                            troverrides.gaapBookPrice,
                            troverrides.statBookValue,
                            troverrides.statBookYield,
                            troverrides.statBookPrice,
                            troverrides.tradePrice,
                            troverrides.marketValue,
                            troverrides.totalMarketValue,
                            troverrides.primarySecurityID,
                            troverrides.majorClass,
                            troverrides.subClass,
                            troverrides.securityDescription,
                            troverrides.naicRating,
                            troverrides.htimEffectiveRating,
                            troverrides.tradeConvexity,
                            troverrides.tradeYield,
                            troverrides.tradeYTC,
                            troverrides.tradeDuration,
                            troverrides.tradeSpread,
                            troverrides.tradeWAL,
                            troverrides.tradeExcluded,
                            troverrides.createDate,
                            troverrides.deleteDate,
                            troverrides.tradeVersion,
                            StatusCd = 1,
                            IsApproved = false,
                            IsUpdated = false,
                            IsDeleted = true,
                            EnteredBy = user,
                            flag = 3

                        }, commandType: CommandType.StoredProcedure);
                        if (returnVal != 0)
                            successFlag = false;
                        if (!successFlag)
                            break;
                    }
                    _connection.Close();
            }
            catch (SqlException ex)
            {
                successFlag = false;
            }
            return successFlag;
        }

        public async Task<List<TradesAudit>> tradesToApprove(string user)
        {
            IEnumerable<TradesAudit> tradesAudit = await GetTableValuesBySpWithParams<TradesAudit>("TradesViewer.GetAllTradesFromAudit",user);
            return tradesAudit.ToList();

        }

        public async Task<List<TradesOverrideAudit>> overridesToApprove(string user)
        {
            IEnumerable<TradesOverrideAudit> overridesAudit = await GetTableValuesBySpWithParams<TradesOverrideAudit>("TradesViewer.GetOverridesFromAudit",user);
            return overridesAudit.ToList();
        }

        public async Task<bool> approveTrades(List<int> tradeIds, string approver)
        {
            int returnVal = 0;
            int transValue = 0;
            string storedProc = "TradesViewer.ApproveLoan";
            try
            {
                    _connection.Open();
                    foreach (var id in tradeIds)
                    {
                        transValue = Math.Abs(await _connection.ExecuteAsync("TradesViewer.Approve",
                            new { id = id, approvedBy = approver,flag=1 },
                            commandType: CommandType.StoredProcedure));
                        returnVal += transValue;
                    }
                    _connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return returnVal == tradeIds.Count ? true : false;
        }

        public async Task<bool> approveOverrides(List<int> overrideIds, string approver)
        {
            int returnVal = 0;
            int transValue = 0;
            string storedProc = "TradesViewer.ApproveLoan";
            try
            {
                    _connection.Open();
                    foreach (var id in overrideIds)
                    {
                        transValue = Math.Abs(await _connection.ExecuteAsync("TradesViewer.Approve",
                            new { id = id, approvedBy = approver, flag = 2 },
                            commandType: CommandType.StoredProcedure));
                        returnVal += transValue;
                    }
                    _connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return returnVal == overrideIds.Count ? true : false;
        }
    }
}
