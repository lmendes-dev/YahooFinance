namespace YahooFinance.Core.Entities
{
    public class YahooFinanceItem
    {
        public string dateFromTimestamp { get; set; }
        public decimal open { get; set; }
        public decimal variationPercentageD1 { get; set; }
        public decimal variationPercentageLine { get; set; }
    }
}
