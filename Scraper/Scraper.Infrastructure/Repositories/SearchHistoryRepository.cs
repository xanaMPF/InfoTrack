using Microsoft.EntityFrameworkCore;
using Scraper.Domain.Repositories;
using Scraper.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scraper.Infrastructure.Repositories
{
    public class SearchHistoryRepository : ISearchHistoryRepository
    {
        private readonly ScraperContext dbContext;
        public SearchHistoryRepository(ScraperContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task InsertHistoryAsync(SearchHistory searchHistory)
        {
            searchHistory.Date = DateTime.Today;
            var row = await dbContext
                      .SearchHistories
                      .AsQueryable()
                      .Where(sh => sh.SearchEngineId == searchHistory.SearchEngineId && sh.Url == searchHistory.Url && sh.Date == searchHistory.Date && sh.Keywords == searchHistory.Keywords)
                      .FirstOrDefaultAsync();

            if (row != null)
            {
                row.Result = searchHistory.Result;
            }
            else
            {
                dbContext.SearchHistories.Add(searchHistory);
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SearchHistory>> GetAllAsync(string keywords, string url, DateTime fromDate)
            => await dbContext
                      .SearchHistories
                      .Include(x => x.SearchEngine)
                      .AsQueryable()
                      .Where(sh => sh.Url == url && sh.Date >= fromDate && sh.Keywords == keywords)
                      .AsNoTracking()
                      .ToListAsync();

        public async Task<IEnumerable<SearchHistory>> GetAllAsync(string keywords, string url, List<DateTime> dates)
            => await dbContext
                          .SearchHistories
                          .Include(x => x.SearchEngine)
                          .AsQueryable()
                          .Where(sh => sh.Url == url && dates.Contains(sh.Date) && sh.Keywords == keywords)
                          .AsNoTracking()
                          .ToListAsync();
    }
}
