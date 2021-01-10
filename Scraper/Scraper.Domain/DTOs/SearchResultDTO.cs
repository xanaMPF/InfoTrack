using System.Collections.Generic;
using System.Linq;

namespace Scraper.Domain.DTOs
{
    public class SearchResultDTO
    {
        public int SearchEngineId { get; set; }
        public string SearchEngineName { get; set; }
        public IEnumerable<int> Ranks { get; set; }

        public int? BestRank => Ranks != null && Ranks.ToList().Count != 0 ? Ranks.ToList().Min() : (int?)null;
    }
}
