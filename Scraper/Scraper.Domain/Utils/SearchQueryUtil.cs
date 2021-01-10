namespace Scraper.Domain.Utils
{
    public static class SearchQueryUtil
    {
        private const int SEARCH_LIMIT = 100;
        public static string GetQueryAppend(string keywords, string searchEngineQuery, string searchEngineLimit)
        {
            var parsedKeywords = keywords.Replace(" ", "+");
            return $"?{searchEngineQuery}={parsedKeywords}&{searchEngineLimit}={SEARCH_LIMIT}";
        }
    }
}
