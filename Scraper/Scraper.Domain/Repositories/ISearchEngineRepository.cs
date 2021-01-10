using Scraper.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scraper.Domain.Repositories
{
    public interface ISearchEngineRepository
    {
        Task<IEnumerable<SearchEngine>> GetAllAsync();

        Task<IEnumerable<SearchEngine>> GetByIds(List<int> Ids);
    }
}
