using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using YahooFinance.Core.Entities.External;

namespace YahooFinance.Infrastructure.Service
{
    public class YahooService : IYahooService
    {
        private readonly IConfiguration _configuration;
        public YahooService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ExternalYahooFinance> GetServiceUri(string currency)
        {
            ExternalYahooFinance externalYahooFinance = null;
            string urlV8 = $"{_configuration["YahooFinanceApiUrl"]}?symbol={currency}&interval=1d&range=1mo";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(urlV8);

                if (!response.IsSuccessStatusCode) return null;

                string responseBody = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(responseBody)) return null;

                externalYahooFinance = JsonConvert.DeserializeObject<ExternalYahooFinance>(responseBody);
            }

            return externalYahooFinance;
        }
    }
}
