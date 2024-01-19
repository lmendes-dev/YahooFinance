using YahooFinance.Core.Entities.External;

namespace YahooFinance.Infrastructure.Service
{
    public interface IYahooService
    {
        Task<ExternalYahooFinance> GetServiceUri(string requestUrl);
    }
}
