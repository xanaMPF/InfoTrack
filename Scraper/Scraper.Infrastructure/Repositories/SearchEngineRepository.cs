using Microsoft.EntityFrameworkCore;
using Scraper.Domain.Repositories;
using Scraper.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scraper.Infrastructure.Repositories
{
    public class SearchEngineRepository : ISearchEngineRepository
    {
        private readonly ScraperContext dbContext;

        public SearchEngineRepository(ScraperContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<SearchEngine>> GetAllAsync()
            => await dbContext
                .SearchEngines
                .AsNoTracking()
                .ToListAsync();

        public async Task<IEnumerable<SearchEngine>> GetByIds(List<int> Ids)
             => await dbContext
                .SearchEngines
                .AsQueryable()
                .Where(x => Ids.Contains(x.Id))
                .AsNoTracking()
                .ToListAsync();

    }
}
