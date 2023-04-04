using HTIM.Trades.Business.Helpers;
using HTIM.Trades.Business.Interfaces;
using HTIM.Trades.Model;
using HTIM.Trades.Services;

namespace HTIM.Trades.Business.Facade
{
    public class TradesFacade : ITradesFacade
    {
        private readonly ITradesService _batchLogService;

        public TradesFacade(ITradesService batchService)
        {
            _batchLogService = batchService;
        }

        public async Task<List<Trade>> GetAllTrades()
        {
            return await _batchLogService.GetAllTrades();
        }

        //public async Task<List<TradesOverride>> GetAllOutOfThresholdLogs()
        //{
        //    return await _batchLogService.GetAllOutOfThresholdLogs();
        //}

        //public async Task<List<TradesOverride>> GetOOTLogsFilteredByProcessCode(string batchProcessCode)
        //{
        //    return await _batchLogService.GetOOTLogsFilteredByProcessCode(batchProcessCode);
        //}

        //public async Task<List<TradesOverride>> GetOutOfThresholdLogsByDate(string fromDate, string toDate)
        //{
        //    DateTime parsedFromDate, parsedToDate;
        //    List<TradesOverride> returnValue;

        //    if (DateTime.TryParse(fromDate, out parsedFromDate))
        //    {
        //        if (DateTime.TryParse(toDate, out parsedToDate))
        //        {
        //            returnValue = await _batchLogService.GetOutOfThresholdLogsByDate(parsedFromDate, parsedToDate);
        //        }
        //        else
        //            throw new AppException("Incorrect todate. Please pass valid datetime format");
        //    }
        //    else
        //        throw new AppException("Incorrect fromdate. Please pass valid datetime format");
        //    return returnValue;
        //}

        //public async Task<List<TradesOverride>> GetLogsFilteredByDate(string fromDate, string toDate)
        //{   
        //    DateTime parsedFromDate,parsedToDate;
        //    List<TradesOverride> returnValue;

        //    if(DateTime.TryParse(fromDate,out parsedFromDate))
        //    {
        //        if (DateTime.TryParse(toDate, out parsedToDate))
        //        {
        //            returnValue= await _batchLogService.GetLogsFilteredByDate(parsedFromDate, parsedToDate);
        //        }
        //        else
        //            throw new AppException("Incorrect todate. Please pass valid datetime format");
        //    }
        //    else
        //        throw new AppException("Incorrect fromdate. Please pass valid datetime format");
        //    return returnValue;  
        //}

        //public async Task<List<TradesOverride>> GetLogsFilteredByProcessCode(string batchProcessCode)
        //{
        //    return await _batchLogService.GetLogsFilteredByProcessCode(batchProcessCode);
        //}

        //public async Task<List<Processes>> getProcesses(string months)
        //{
        //    return await _batchLogService.getProcesses(months);
        //}

        public async Task<List<ChartInfo>> getChartInfo(string months)
        {
            return await _batchLogService.getChartInfo(months);
        }
        //public async Task<List<TradesOverride>> GetLogsByCodeAndDate(string processCode, string fromDate, string toDate)
        //{
        //    DateTime parsedFromDate, parsedToDate;
        //    List<TradesOverride> returnValue;

        //    if (DateTime.TryParse(fromDate, out parsedFromDate))
        //    {
        //        if (DateTime.TryParse(toDate, out parsedToDate))
        //        {
        //            returnValue = await _batchLogService.GetLogsByCodeAndDate(processCode,parsedFromDate, parsedToDate);
        //        }
        //        else
        //            throw new AppException("Incorrect todate. Please pass valid datetime format");
        //    }
        //    else
        //        throw new AppException("Incorrect fromdate. Please pass valid datetime format");

        //    return returnValue;
        //}

        //public async Task<List<TradesOverride>> GetOOTLogsByCodeAndDate(string processCode, string fromDate, string toDate)
        //{
        //    DateTime parsedFromDate, parsedToDate;
        //    List<TradesOverride> returnValue;

        //    if (DateTime.TryParse(fromDate, out parsedFromDate))
        //    {
        //        if (DateTime.TryParse(toDate, out parsedToDate))
        //        {
        //            returnValue = await _batchLogService.GetOOTLogsByCodeAndDate(processCode, parsedFromDate, parsedToDate);
        //        }
        //        else
        //            throw new AppException("Incorrect todate. Please pass valid datetime format");
        //    }
        //    else
        //        throw new AppException("Incorrect fromdate. Please pass valid datetime format");

        //    return returnValue;
        //}

        //public Task<List<TradesOverride>> GetAllCleanTrades()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
