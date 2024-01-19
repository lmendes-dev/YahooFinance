using YahooFinance.Core.Entities;

namespace YahooFinance.Core.Repositories
{
    public interface IYahooRepository
    {
        Task<YahooFinanceClass> GetYahoo(string yahooName);
        Task<YahooFinanceClass> UpdateYahoo(string yahooName, YahooFinanceClass yahooFinance);
        Task DeleteYahoo(string yahooName);
    }
}
