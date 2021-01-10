using Scraper.Domain.DTOs;
using Scraper.Domain.Utils;
using Scraper.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scraper.Domain.Services.WebScraper
{
    public class ScraperService : IScraperService
    {
        private readonly HttpClient httpClient;
        private const string HEADER_NAME = "User-Agent";
        private const string HEADER_VALUE = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:71.0) Gecko/20100101 Firefox/71.0";

        public ScraperService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.DefaultRequestHeaders.TryAddWithoutValidation(HEADER_NAME, HEADER_VALUE);
        }

        public async Task<SearchResultDTO> GetRankingsForKeyword(SearchEngine searchEngine, string matchingUrl, string keywords)
        {
            MatchCollection tags = await GetRegexMatchesAsync(searchEngine, keywords);

            var ranks = new List<int>();
                        
            for (var index = 0; index < tags.Count; index++)
            {
                if (tags[index].Value.Contains(matchingUrl))
                {
                    ranks.Add(index + 1);
                }
            }

            return new SearchResultDTO()
            {
                Ranks = ranks.Count == 0 ? null : ranks,
                SearchEngineId = searchEngine.Id,
                SearchEngineName = searchEngine.Name,
            };
        }

        private async Task<MatchCollection> GetRegexMatchesAsync(SearchEngine searchEngine, string keywords)
        {
            var html = await LoadHtmlForKeywordAsync(searchEngine, keywords);

            var tagRegex = new Regex(searchEngine.RegexTag, RegexOptions.Singleline);
            var tags = tagRegex.Matches(html);
            return tags;
        }

        private async Task<string> LoadHtmlForKeywordAsync(SearchEngine searchEngine, string keywords)
        {
            var query = SearchQueryUtil.GetQueryAppend(keywords, searchEngine.Query, searchEngine.Limit);
            var request = new Uri(searchEngine.BaseAddress + query);

            return await (await httpClient.GetAsync(request)).Content.ReadAsStringAsync();
        }
    }
}
