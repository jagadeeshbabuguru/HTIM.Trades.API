
namespace HTIM.Trades.Model
{
    public class TradesOverride
    {
        public int TradesOverrideID { set; get; }
        public int TradeID { set; get; }
        public DateTime? TradeEffectiveDate { set; get; }
        public decimal? GAAPBookValue { set; get; }
        public decimal? GAAPBookYield { set; get; }
        public decimal? GAAPBookPrice { set; get; }
        public decimal? STATBookValue { set; get; }
        public decimal? STATBookYield { set; get; }
        public decimal? STATBookPrice { set; get; }
        public decimal? TradePrice { set; get; }
        public decimal? MarketValue { set; get; }
        public decimal? TotalMarketValue { set; get; }
        public string? PrimarySecurityID { set; get; }
        public string? MajorClass { set; get; }
        public string? SubClass { set; get; }
        public string? SecurityDescription { set; get; }
        public string? NAICRating { set; get; }
        public string? HTIMEffectiveRating { set; get; }
        public decimal? TradeConvexity { set; get; }
        public decimal? TradeYield { set; get; }
        public decimal? TradeYTC { set; get; }
        public decimal? TradeDuration { set; get; }
        public decimal? TradeSpread { set; get; }
        public decimal? TradeWAL { set; get; }
        public bool TradeExcluded { set; get; }
        public DateTime? CreateDate { set; get; }
        public DateTime? DeleteDate { set; get; }
        public int? TradeVersion { set; get; }


    }
}

