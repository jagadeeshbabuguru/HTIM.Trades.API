using Moq;
using HTIM.Trades.Services;
using HTIM.Trades.Business.Facade;

namespace HTIM.Trades.Testing
{
    public class TradesFacadeTests
    {
        private readonly TradesFacade TradesFacade;
        private readonly Mock<ITradesService> batchLogService=new Mock<ITradesService>();
        public TradesFacadeTests()
        {
            TradesFacade = new TradesFacade(batchLogService.Object);
        }
        [Fact]
        public async Task TestGetAllBatchLogs()
        {
            string batchProcessName = "Cashflows";
            string fromDate = "09/22/2022";
            string toDate = "09/29/2022";
            batchLogService.Setup(x => x.GetAllBatchLogs()).ReturnsAsync(TestResults.getAllLogs());
            batchLogService.Setup(x => x.GetAllOutOfThresholdLogs()).ReturnsAsync(TestResults.getOOTLogs);
            batchLogService.Setup(x => x.GetLogsFilteredByProcessCode(batchProcessName)).ReturnsAsync(TestResults.getLogsByProcess);
            batchLogService.Setup(x => x.GetLogsFilteredByDate(DateTime.Parse(fromDate), DateTime.Parse(toDate))).ReturnsAsync(TestResults.getLogsByDate);
            batchLogService.Setup(x => x.GetOutOfThresholdLogsByDate(DateTime.Parse(fromDate), DateTime.Parse(toDate))).ReturnsAsync(TestResults.GetOOTLogsBydate);
            batchLogService.Setup(x => x.GetLogsByCodeAndDate(batchProcessName, DateTime.Parse(fromDate), DateTime.Parse(toDate))).ReturnsAsync(TestResults.getOOTLogsBydateAndProcess);
            batchLogService.Setup(x => x.GetOOTLogsByCodeAndDate(batchProcessName, DateTime.Parse(fromDate), DateTime.Parse(toDate))).ReturnsAsync(TestResults.getOOTLogsBydateAndProcess);

            var allLogs=await TradesFacade.GetAllBatchLogs();
            var ootlogs = await TradesFacade.GetAllOutOfThresholdLogs();
            var logsbyprocesscode = await TradesFacade.GetLogsFilteredByProcessCode(batchProcessName);
            var logsbydate = await TradesFacade.GetLogsFilteredByDate(fromDate, toDate);
            var ootlogsbydate = await TradesFacade.GetOutOfThresholdLogsByDate(fromDate, toDate);
            var logsbycodeanddate = await TradesFacade.GetLogsByCodeAndDate(batchProcessName, fromDate, toDate);
            var ootlogsbycodeanddate = await TradesFacade.GetOOTLogsByCodeAndDate(batchProcessName, fromDate, toDate);
            
            Assert.Contains(allLogs, x =>x.TransactionId== 2022092217006011);
            Assert.Contains(ootlogs, x => x.TransactionId == 202209237686785775);
            Assert.Contains(logsbyprocesscode, x => x.TransactionId == 20220922170331211);
            Assert.Contains(logsbydate, x => x.TransactionId == 2022092312017001);
            Assert.Contains(ootlogsbydate, x => x.TransactionId == 202209221243432);
            Assert.Contains(logsbycodeanddate, x => x.TransactionId == 202209221243432);
            Assert.Contains(ootlogsbycodeanddate, x => x.TransactionId == 202209221243432);
        }
       
    }
}