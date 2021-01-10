using Scraper.Domain.DTOs;
using Scraper.Infrastructure.Models;
using System.Threading.Tasks;

namespace Scraper.Domain.Services.WebScraper
{
    public interface IScraperService
    {
        Task<SearchResultDTO> GetRankingsForKeyword(SearchEngine searchEngine, string matchingUrl, string keywords);
    }
}
