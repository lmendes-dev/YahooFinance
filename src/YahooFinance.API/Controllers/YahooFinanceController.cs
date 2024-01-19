using Microsoft.AspNetCore.Mvc;
using YahooFinance.Core.Repositories;
using YahooFinance.Infrastructure.Adapter;
using YahooFinance.Infrastructure.Helper;
using YahooFinance.Infrastructure.Service;

namespace YahooFinance.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class YahooFinanceController : ControllerBase
    {
        private readonly IYahooService _yahooService;
        private readonly IYahooRepository _repository;

        public YahooFinanceController(IYahooService yahooService, IYahooRepository repository)
        {
            _yahooService = yahooService;
            _repository = repository;
        }

        [HttpGet(Name = "GetFinance")]
        public async Task<IActionResult> Get(string currency)
        {
            if (string.IsNullOrEmpty(currency)) return BadRequest("A moeda não pode ser vazia ou nula.");

            var name = GlobalFunction.GetName(currency);

            var yahooFinance = await _repository.GetYahoo(name);
            if (yahooFinance != null) return Ok(yahooFinance);

            var externalYahooFinance = await _yahooService.GetServiceUri(currency);
            if (externalYahooFinance == null) return BadRequest("Moeda não encontrada externamente.");

            var adapter = new YahooFinanceAdapter();
            yahooFinance = adapter.GenerateYahooFinance(externalYahooFinance);

            await _repository.UpdateYahoo(name, yahooFinance);

            return Ok(yahooFinance);
        }
    }
}
