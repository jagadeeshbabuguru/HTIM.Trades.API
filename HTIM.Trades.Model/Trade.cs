
namespace HTIM.Trades.Model
{
    [System.Serializable]
    public class Trade
    {
        public int? rowID { set; get; }
        public String? bcusip { set; get; }
        public int? fundNumber { set; get; }
        public int? invNumber { set; get; }
        public int? tradeNumber { set; get; }
        public int? tradeVersion { set; get; }
        public string? aladdinPort { set; get; }
        public string? tranType { set; get; }
        public string? tranSource { set; get; }
        public DateTime? tradeEntry { set; get; }
        public DateTime? tradeEffectiveDate { set; get; }
        public DateTime? tradeDate { set; get; }
        public DateTime? settleDate { set; get; }
        public string? brokerName { set; get; }
        public decimal? gaapBookValue { set; get; }
        public decimal? gaapBookYield { set; get; }
        public decimal? gaapBookPrice { set; get; }
        public decimal? statBookValue { set; get; }
        public decimal? statBookYield { set; get; }
        public decimal? statBookPrice { set; get; }
        public decimal? marketValue { set; get; }
        public decimal? accruedInterest { set; get; }
        public decimal? totalMarketValue { set; get; }
        public decimal? originalFace { set; get; }
        public decimal? tradePrice { set; get; }
        public decimal? tradePrincipal { set; get; }
        public decimal? currentFace { set; get; }
        public string? htimid { set; get; }
        public string? majorClass { set; get; }
        public string? subClass { set; get; }
        public string? couponType { set; get; }
        public string? secDesc { set; get; }
        public decimal? coupon { set; get; }
        public string? couponFrequency { set; get; }
        public string? currency { set; get; }
        public string? maturityDate { set; get; }
        public string? priceStyle { set; get; }
        public string? securityType { set; get; }
        public string? securityTicker { set; get; }
        public string? isin { set; get; }
        public string? sedol { set; get; }
        public string? moodysRating { set; get; }
        public DateTime? moodysRatingDate { set; get; }
        public string? spRating { set; get; }
        public DateTime? spRatingDate { set; get; }
        public string? fitchRating { set; get; }
        public DateTime? fitchRatingDate { set; get; }
        public string? dbrsRating { set; get; }
        public DateTime? dbrsRatingDate { set; get; }
        public string? naicRating { set; get; }
        public DateTime? naicRatingDate { set; get; }
        public string? htimEffectiveRating { set; get; }
        public decimal? tradeConvexity { set; get; }
        public decimal? tradeYield { set; get; }
        public decimal? tradeYTC { set; get; }
        public decimal? tradeDuration { set; get; }
        public decimal? tradeSpread { set; get; }
        public decimal? tradeWAL { set; get; }    
        public bool? tradeExcluded { set; get; }
        public bool? tradeCancelled { set; get; }
        public DateTime? loadDate { set; get; }
        public DateTime? deleteDate { set; get;}
        public DateTime? modifiedDate { set; get;}
        public List<TradesOverride>? overrides { set; get; }
        public int? isFromAudit { set; get; }

    }
}

