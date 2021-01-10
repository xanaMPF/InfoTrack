using Microsoft.AspNetCore.Mvc;
using Scraper.Domain.DTOs;
using Scraper.Domain.Services.SearchResults;
using System;
using System.Threading.Tasks;

namespace Scraper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RanksController : ControllerBase
    {
        private readonly ISearchResultsService service;

        public RanksController(ISearchResultsService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult> FetchRankingAsync([FromBody] SearchRequestDTO query)
        {
            try
            {
                return Ok(await service.FetchRankingAsync(query));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("Daily")]
        public async Task<ActionResult> GetDailyHistoricalRankingsAsync([FromBody] SearchRequestBaseDTO query)
        {
            try
            {
                return Ok(await service.GetDailyRankingAsync(query));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
