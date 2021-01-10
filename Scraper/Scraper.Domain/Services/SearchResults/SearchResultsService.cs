using AutoMapper;
using Scraper.Domain.DTOs;
using Scraper.Domain.Repositories;
using Scraper.Domain.Services.WebScraper;
using Scraper.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scraper.Domain.Services.SearchResults
{
    public class SearchResultsService : ISearchResultsService
    {
        private readonly IScraperService webScraperService;
        private readonly ISearchEngineRepository searchEngineRepository;
        private readonly ISearchHistoryRepository searchHistoryRepository;
        private readonly IMapper mapper;
        private const int DAILY_HISTORY_IN_DAYS = 15;

        public SearchResultsService(IScraperService webScraperService, 
                                    ISearchEngineRepository searchEnginesService,
                                    ISearchHistoryRepository searchHistoryRepository,
                                    IMapper mapper)                              
        {
            this.webScraperService = webScraperService;
            this.searchEngineRepository = searchEnginesService;
            this.searchHistoryRepository = searchHistoryRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SearchResultDTO>> FetchRankingAsync(SearchRequestDTO query)
        {
            var searchEngines = await searchEngineRepository.GetByIds(query.SearchEngineIds);
            var searchResults = new List<SearchResultDTO>();

            foreach (var searchEngine in searchEngines)
            {
                var searchResult = await webScraperService.GetRankingsForKeyword(searchEngine, query.Url, query.Keywords);

                var mappedPartialSearchHistory = mapper.Map<SearchRequestDTO, SearchHistory>(query);
                var searchHistory = mapper.Map(searchResult, mappedPartialSearchHistory);
                searchHistory.SearchEngineId = searchEngine.Id;

                await searchHistoryRepository.InsertHistoryAsync(searchHistory);
                searchResults.Add(searchResult);
            }

            return searchResults;
        }

        public async Task<IEnumerable<HistoricalSearchResultDTO>> GetDailyRankingAsync(SearchRequestBaseDTO query)
        {
            List<HistoricalSearchResultDTO> result = GetEmptyHistoricalSearchByDay();

            var history = await searchHistoryRepository.GetAllAsync(query.Keywords, query.Url, DateTime.Today.AddDays(-DAILY_HISTORY_IN_DAYS));
            history.GroupBy(x => x.Date)
                .ToList()
                .ForEach(hist =>
                {
                    var historicalSearch = new Dictionary<string, SearchResultDTO>();
                    hist.ToList().ForEach(r =>
                    {
                        var dto = MapToSearchResultDTO(r);
                        historicalSearch.Add(r.SearchEngine.Name, dto);
                    });

                    var res = result.FirstOrDefault(res => res.Date == hist.Key);
                    res.Results = historicalSearch;
                });
            return result;
        }

        private SearchResultDTO MapToSearchResultDTO(SearchHistory r)
        {
            var dto = mapper.Map<SearchResultDTO>(r);
            dto.Ranks = string.IsNullOrEmpty(r.Result)
                        ? null
                        : r.Result.Split(", ").Select(x => Int32.Parse(x));
            return dto;
        }

        private static List<HistoricalSearchResultDTO> GetEmptyHistoricalSearchByDay()
        {
            return Enumerable.Range(0, DAILY_HISTORY_IN_DAYS+1)
                .Select(offset =>
                {
                    return new HistoricalSearchResultDTO()
                    {
                        Date = DateTime.Today.AddDays(-offset),
                    };
                })
                .ToList();
        }
    }
}
