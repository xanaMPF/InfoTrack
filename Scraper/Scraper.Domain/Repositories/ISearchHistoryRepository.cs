using Scraper.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scraper.Domain.Repositories
{
    public interface ISearchHistoryRepository
    {
        Task InsertHistoryAsync(SearchHistory searchHistory);

        Task<IEnumerable<SearchHistory>> GetAllAsync(string keywords, string url, DateTime fromDate);

        Task<IEnumerable<SearchHistory>> GetAllAsync(string keywords, string url, List<DateTime> fromDate);
    }
}
