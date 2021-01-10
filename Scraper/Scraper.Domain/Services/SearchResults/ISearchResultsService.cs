using Scraper.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scraper.Domain.Services.SearchResults
{
    public interface ISearchResultsService
    {
        Task<IEnumerable<SearchResultDTO>> FetchRankingAsync(SearchRequestDTO query);

        Task<IEnumerable<HistoricalSearchResultDTO>> GetDailyRankingAsync(SearchRequestBaseDTO query);
    }
}
