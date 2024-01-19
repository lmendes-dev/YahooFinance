using YahooFinance.Core.Entities.External;
using YahooFinance.API.Controllers;
using Moq;
using Newtonsoft.Json;
using YahooFinance.Core.Entities;
using YahooFinance.Core.Repositories;
using YahooFinance.Infrastructure.Service;
using Microsoft.Extensions.Configuration;
using static YahooFinance.UnitTest.Get_ReturnsYahooFinance;
using Microsoft.AspNetCore.Mvc;

namespace YahooFinance.UnitTest
{
    public class Get_ReturnsYahooFinance : IClassFixture<ConfigurationFixture>
    {
        private readonly IConfiguration _configuration;
        public Get_ReturnsYahooFinance(ConfigurationFixture fixture)
        {
            _configuration = fixture.Configuration;
        }

        [Fact]
        public async void Test1()
        {
            // Arrange
            var externalYahooFinance =
            JsonConvert.DeserializeObject<ExternalYahooFinance>
                (
                    File.ReadAllText(_configuration["YahooFinanceJson"])
                );

            var mockYahooService = new Mock<IYahooService>();
            mockYahooService.Setup(x => x.GetServiceUri(It.IsAny<string>())).ReturnsAsync(externalYahooFinance);

            var mockRepository = new Mock<IYahooRepository>();

            mockRepository.Setup(x => x.GetYahoo(It.IsAny<string>())).ReturnsAsync((string yahooName) => null);

            mockRepository.Setup(x => x.UpdateYahoo(It.IsAny<string>(), It.IsAny<YahooFinanceClass>()))
            .ReturnsAsync((string yahooName, YahooFinanceClass updatedFinance) =>
            {
                return updatedFinance;
            });

            var controller = new YahooFinanceController(mockYahooService.Object, mockRepository.Object);

            // Act
            var actionResult = await controller.Get("PETR4.SA");

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
            var okObjectResult = (OkObjectResult)actionResult;

            Assert.IsType<YahooFinanceClass>(okObjectResult.Value);
            var result = (YahooFinanceClass)okObjectResult.Value;

            // Assert
            Assert.IsType<YahooFinanceClass>(result);
            //Validando o retorno da variação D1
            Assert.Equal(0, result.Items[0].variationPercentageD1);
            Assert.Equal(10m, result.Items[1].variationPercentageD1);
            Assert.Equal(-4.55m, result.Items[2].variationPercentageD1);
            Assert.Equal(80.95m, result.Items[3].variationPercentageD1);

            //Validando o retorno da variação da primeira linha
            Assert.Equal(0, result.Items[0].variationPercentageLine);
            Assert.Equal(10m, result.Items[1].variationPercentageLine);
            Assert.Equal(5m, result.Items[2].variationPercentageLine);
            Assert.Equal(90m, result.Items[3].variationPercentageLine);

            mockRepository.Verify(x => x.UpdateYahoo(It.IsAny<string>(), It.IsAny<YahooFinanceClass>()), Times.Once);
        }

        public class ConfigurationFixture : IDisposable
        {
            public IConfiguration Configuration { get; }
            public ConfigurationFixture()
            {
                Configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            }
            public void Dispose() { }
        }
    }
}