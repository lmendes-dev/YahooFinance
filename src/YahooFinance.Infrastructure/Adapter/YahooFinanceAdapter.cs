using YahooFinance.Core.Entities;
using YahooFinance.Core.Entities.External;
using YahooFinance.Infrastructure.Builder;

namespace YahooFinance.Infrastructure.Adapter
{
    public class YahooFinanceAdapter
    {
        public YahooFinanceClass GenerateYahooFinance(ExternalYahooFinance externalYahooFinance)
        {
            var builder = new YahooFinanceBuilder();
            var yahooFinanceByBuilder = builder
                .Start()
                .WithMeta(externalYahooFinance)
                .WithItens(externalYahooFinance)
                .Build();

            return yahooFinanceByBuilder;
        }
    }
}
