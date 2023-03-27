namespace HTIM.Trades.Model
{
    public class Processes
    {
        public int ProcessID { set; get; }
        public string ProcessName { set; get; }
        public int errorCount { set; get; }
        public int warningsCount { set; get; }
        public int successCount { set; get; }
        public int thresholdValue { set; get; }
        public string runTime { set; get; }
    }
}