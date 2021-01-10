using Microsoft.AspNetCore.Mvc;
using Scraper.Domain.Services.SearchEngines;
using System.Threading.Tasks;

namespace Scraper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchEnginesController : ControllerBase
    {
        private readonly ISearchEnginesService service;

        public SearchEnginesController(ISearchEnginesService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await service.GetSearchEnginesBaseInfo());
        }
    }
}
