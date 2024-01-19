using YahooFinance.Core.Entities.External;
using YahooFinance.Core.Entities;

namespace YahooFinance.Infrastructure.Builder
{
    public class YahooFinanceBuilder
    {
        private YahooFinanceClass _yahooFinance;
        public YahooFinanceBuilder()
        {

        }
        public YahooFinanceBuilder Start()
        {
            _yahooFinance = new YahooFinanceClass
            {
                Items = new List<YahooFinanceItem>()
            };
            return this;
        }

        public YahooFinanceBuilder WithMeta(ExternalYahooFinance externalYahooFinance)
        {
            _yahooFinance.currency = externalYahooFinance.chart.result[0].meta.currency;
            _yahooFinance.symbol = externalYahooFinance.chart.result[0].meta.symbol;
            return this;
        }

        public YahooFinanceBuilder WithItens(ExternalYahooFinance externalYahooFinance)
        {
            if (externalYahooFinance.chart.result[0].timestamp.Count != externalYahooFinance.chart.result[0].indicators.quote[0].open.Count)
            {
                throw new Exception("Ocorreu um erro ao desserializar o JSON.");
            }

            decimal openFirstLine = 0;
            for (int i = 0; i < externalYahooFinance.chart.result[0].timestamp.Count; i++)
            {
                //Change TimeStamp to Format-Date(dd/mm/yyyy)
                long timestamp = externalYahooFinance.chart.result[0].timestamp[i];
                string dateFromTimestamp = FormatDate(timestamp);

                //Field Open
                double? open = externalYahooFinance.chart.result[0].indicators.quote[0].open[i];
                decimal openDecimal = open.HasValue ? Convert.ToDecimal(open.GetValueOrDefault()) : 0.0m;

                //Field Before D1
                double? openBefore = i > 0 ? externalYahooFinance.chart.result[0].indicators.quote[0].open[i - 1] : 0;
                decimal openDecimalBefore = openBefore.HasValue ? Convert.ToDecimal(openBefore.GetValueOrDefault()) : 0.0m;
                decimal variationPercentageD1 = i > 0 ? CalculatePercentage(openDecimalBefore, openDecimal) : 0;

                //Field FirstLine                
                if (i == 0) openFirstLine = openDecimal;
                decimal variationPercentageLine = i > 0 ? CalculatePercentage(openFirstLine, openDecimal) : 0;

                _yahooFinance.Items.Add(new YahooFinanceItem
                {
                    dateFromTimestamp = dateFromTimestamp,
                    open = Math.Round(openDecimal, 2),
                    variationPercentageD1 = variationPercentageD1,
                    variationPercentageLine = variationPercentageLine
                });
            }

            return this;
        }

        public YahooFinanceClass Build()
        {
            return _yahooFinance;
        }

        public decimal CalculatePercentage(decimal previousValue, decimal currentValue)
        {
            decimal variationPercentual = 0;
            // Verifica se o valor anterior é zero para evitar divisão por zero
            if (previousValue == 0 || currentValue == 0.0m || currentValue == null)
            {
                return 0;
            }

            // Calcula a variação percentual
            variationPercentual = (currentValue - previousValue) / previousValue * 100;

            return Math.Round(variationPercentual, 2);
        }

        public string FormatDate(long timestamp)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp);
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            DateTimeOffset dataHoraBRT = TimeZoneInfo.ConvertTime(dateTimeOffset, timeZone);

            string dataFormatada = dataHoraBRT.ToString("dd/MM/yyyy"); // Formato desejado
            return dataFormatada;
        }
    }
}
