namespace Scraper.Domain.DTOs
{
    public class SearchEngineDTO : SearchEngineBaseDTO
    {
        public string BaseAddress { get; set; }

        public string Query { get; set; }

        public string Limit { get; set; }

        public string TagRegex { get; set; }
    }
}
