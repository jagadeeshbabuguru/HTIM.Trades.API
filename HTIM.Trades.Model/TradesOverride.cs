
namespace HTIM.Trades.Model
{
    [System.Serializable]
    public class TradesOverride
    {
        public int tradesOverrideID { set; get; }
        public int tradeID { set; get; }
        public DateTime? tradeEffectiveDate { set; get; }
        public decimal? gaapBookValue { set; get; }
        public decimal? gaapBookYield { set; get; }
        public decimal? gaapBookPrice { set; get; }
        public decimal? statBookValue { set; get; }
        public decimal? statBookYield { set; get; }
        public decimal? statBookPrice { set; get; }
        public decimal? tradePrice { set; get; }
        public decimal? marketValue { set; get; }
        public decimal? totalMarketValue { set; get; }
        public string? primarySecurityID { set; get; }
        public string? majorClass { set; get; }
        public string? subClass { set; get; }
        public string? securityDescription { set; get; }
        public string? naicRating { set; get; }
        public string? htimEffectiveRating { set; get; }
        public decimal? tradeConvexity { set; get; }
        public decimal? TradeYield { set; get; }
        public decimal? tradeYTC { set; get; }
        public decimal? tradeDuration { set; get; }
        public decimal? tradeSpread { set; get; }
        public decimal? tradeWAL { set; get; }
        public bool tradeExcluded { set; get; }
        public DateTime? createDate { set; get; }
        public DateTime? deleteDate { set; get; }
        public int? tradeVersion { set; get; }

    }
}

