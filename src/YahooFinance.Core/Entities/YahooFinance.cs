namespace YahooFinance.Core.Entities
{
    public class YahooFinanceClass
    {
        public string currency { get; set; }
        public string symbol { get; set; }
        public List<YahooFinanceItem> Items { get; set; }
    }
}
