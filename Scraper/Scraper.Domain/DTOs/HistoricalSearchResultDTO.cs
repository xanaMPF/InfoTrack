using System;
using System.Collections.Generic;

namespace Scraper.Domain.DTOs
{
    public class HistoricalSearchResultDTO
    {
        public DateTime Date { get; set; }

        public Dictionary<string, SearchResultDTO> Results {get;set; }
    }
}
