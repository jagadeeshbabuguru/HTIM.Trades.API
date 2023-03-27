using HTIM.Trades.Model;

namespace HTIM.Trades.Testing
{
    public static class TestResults
    {
        public static List<TradesOverride> getAllLogs()
        {
            List<TradesOverride> logs = new List<TradesOverride>();
            logs.Add(new TradesOverride()
            {
                TransactionId = 2022092217006011,
                ProcessCode = "Cashflows",
                FilePickupName = "cashflows_AEL_",
                LogMessage = "new cashflows_AEL_20220922.csvis arrived at location: C:\\ServiceTesting\\cashflows_AEL_20220922.csv with size of 197425KBAttention",
                LogDate = DateTime.Parse("2022 - 09 - 22 16:52:40.740")
            });
           
            
            return logs;

        }
        public static List<TradesOverride> getLogsByDate()
        {
            List<TradesOverride> logs = new List<TradesOverride>();
            logs.Add(new TradesOverride()
            {
                TransactionId = 2022092312017001,
                ProcessCode = "PlmLoanAEL",
                FilePickupName = "cashflows_AEL_",
                LogMessage = "new cashflows_AEL_20220922.csvis arrived at location: C:\\ServiceTesting\\cashflows_AEL_20220922.csv with size of 197425KBAttention",
               LogDate = DateTime.Parse("2022 - 09 - 27 16:52:40.740")
            });
            return logs;
        }
        public static List<TradesOverride> getLogsByProcess()
        {
            List<TradesOverride> logs = new List<TradesOverride>();
            logs.Add(new TradesOverride()
            {
                TransactionId = 20220922170331211,
                ProcessCode = "PlmPropertyAEL",
                FilePickupName = "PlmPropertyAEL_",
                LogMessage = "new cashflows_AEL_20220922.csvis arrived at location: C:\\ServiceTesting\\cashflows_AEL_20220922.csv with size of 197425KBAttention",
                LogDate = DateTime.Parse("2022 - 09 - 23 16:52:40.740")
            });
            return logs;
        }
        public static List<TradesOverride> GetOOTLogsBydate()
        {
            List<TradesOverride> logs = new List<TradesOverride>();
            logs.Add(new TradesOverride()
            {
                TransactionId = 202209221243432,
                ProcessCode = "Cashflows",
                FilePickupName = "cashflows_AEL_",
                LogMessage = "new cashflows_AEL_20220922.csvis arrived at location: C:\\ServiceTesting\\cashflows_AEL_20220922.csv with size of 197425KBAttention",
               LogDate = DateTime.Parse("2022 - 09 - 22 16:52:40.740")
            });
            return logs;
        }
        public static List<TradesOverride> GetOOTLogs()
        {
            List<TradesOverride> logs = new List<TradesOverride>();
            return logs;
        }

        public static List<TradesOverride> getOOTLogs()
        {
            List<TradesOverride> logs = new List<TradesOverride>();     
            logs.Add(new TradesOverride()
            {
                TransactionId = 202209237686785775,
                ProcessCode = "PlmLoanAEL",
                FilePickupName = "cashflows_AEL_",
                LogMessage = "new cashflows_AEL_20220922.csvis arrived at location: C:\\ServiceTesting\\cashflows_AEL_20220922.csv with size of 197425KBAttention",
                LogDate = DateTime.Parse("2022 - 09 - 27 16:52:40.740")
            });
          
            return logs;
        }
        public static List<TradesOverride> getOOTLogsBydateAndProcess()
        {
            List<TradesOverride> logs = new List<TradesOverride>();
            logs.Add(new TradesOverride()
            {
                TransactionId = 202209221243432,
                ProcessCode = "Cashflows",
                FilePickupName = "cashflows_AEL_",
                LogMessage = "new cashflows_AEL_20220922.csvis arrived at location: C:\\ServiceTesting\\cashflows_AEL_20220922.csv with size of 197425KBAttention",
                LogDate = DateTime.Parse("2022 - 09 - 22 16:52:40.740")
            });
            logs.Add(new TradesOverride()
            {
                TransactionId = 202209237686785775,
                ProcessCode = "PlmLoanAEL",
                FilePickupName = "cashflows_AEL_",
                LogMessage = "new cashflows_AEL_20220922.csvis arrived at location: C:\\ServiceTesting\\cashflows_AEL_20220922.csv with size of 197425KBAttention",
                LogDate = DateTime.Parse("2022 - 09 - 27 16:52:40.740")
            });
            logs.Add(new TradesOverride()
            {
                TransactionId = 20220922534524543,
                ProcessCode = "PlmPropertyAEL",
                FilePickupName = "PlmPropertyAEL_",
                LogMessage = "new cashflows_AEL_20220922.csvis arrived at location: C:\\ServiceTesting\\cashflows_AEL_20220922.csv with size of 197425KBAttention",
                LogDate = DateTime.Parse("2022 - 09 - 23 16:52:40.740")
            });
            return logs;
        }
    }
}
