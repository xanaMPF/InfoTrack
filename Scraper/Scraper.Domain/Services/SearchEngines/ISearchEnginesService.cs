using Scraper.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scraper.Domain.Services.SearchEngines
{
    public interface ISearchEnginesService
    {
        Task<IEnumerable<SearchEngineBaseDTO>> GetSearchEnginesBaseInfo();
    }
}
