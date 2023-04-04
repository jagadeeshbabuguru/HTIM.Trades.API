
namespace HTIM.Trades.Model
{
    public class Trade
    {
        public int RowID { set; get; }
        public String? BCUSIP { set; get; }
        public int FundNumber { set; get; }
        public int InvNumber { set; get; }
        public int TradeNumber { set; get; }
        public int TradeVersion { set; get; }
        public string? AladdinPort { set; get; }
        public string? TranType { set; get; }
        public string? TranSource { set; get; }
        public DateTime? TradeEntry { set; get; }
        public DateTime? TradeEffectiveDate { set; get; }
        public DateTime? TradeDate { set; get; }
        public DateTime? SettleDate { set; get; }
        public string? BrokerName { set; get; }
        public decimal? GAAPBookValue { set; get; }
        public decimal? GAAPBookYield { set; get; }
        public decimal? GAAPBookPrice { set; get; }
        public decimal? STATBookValue { set; get; }
        public decimal? STATBookYield { set; get; }
        public decimal? STATBookPrice { set; get; }
        public decimal? MarketValue { set; get; }
        public decimal? AccruedInterest { set; get; }
        public decimal? TotalMarketValue { set; get; }
        public decimal? OriginalFace { set; get; }
        public decimal? TradePrice { set; get; }
        public decimal? TradePrincipal { set; get; }
        public decimal? CurrentFace { set; get; }
        public string? HTIMID { set; get; }
        public string? MajorClass { set; get; }
        public string? SubClass { set; get; }
        public string? CouponType { set; get; }
        public string? SecDesc { set; get; }
        public decimal? Coupon { set; get; }
        public string? CouponFrequency { set; get; }
        public string? Currency { set; get; }
        public string? MaturityDate { set; get; }
        public string? PriceStyle { set; get; }
        public string? SecurityType { set; get; }
        public string? SecurityTicker { set; get; }
        public string? ISIN { set; get; }
        public string? SEDOL { set; get; }
        public string? MoodysRating { set; get; }
        public DateTime? MoodysRatingDate { set; get; }
        public string? SPRating { set; get; }
        public DateTime? MoodysSPRatingDateRatingDate { set; get; }
        public string? FitchRating { set; get; }
        public DateTime? FitchRatingDate { set; get; }
        public string? DBRSRating { set; get; }
        public DateTime? DBRSRatingDate { set; get; }
        public string? NAICRating { set; get; }
        public DateTime? NAICRatingDate { set; get; }
        public string? HTIMEffectiveRating { set; get; }
        public decimal? TradeConvexity { set; get; }
        public decimal? TradeYield { set; get; }
        public decimal? TradeYTC { set; get; }
        public decimal? TradeDuration { set; get; }
        public decimal? TradeSpread { set; get; }
        public decimal? TradeWAL { set; get; }    
        public bool TradeExcluded { set; get; }
        public bool TradeCancelled { set; get; }
        public DateTime? LoadDate { set; get; }
        public DateTime? DeleteDate { set; get;}
        public DateTime? ModifiedDate { set; get;}
        public List<TradesOverride>? Overrides { set; get; }

    }
}

