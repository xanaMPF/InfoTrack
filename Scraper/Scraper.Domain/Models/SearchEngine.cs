using System;
using System.Collections.Generic;

#nullable disable

namespace Scraper.Infrastructure.Models
{
    public partial class SearchEngine
    {
        public SearchEngine()
        {
            SearchHistories = new HashSet<SearchHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string BaseAddress { get; set; }
        public string Query { get; set; }
        public string Limit { get; set; }
        public string RegexTag { get; set; }

        public virtual ICollection<SearchHistory> SearchHistories { get; set; }
    }
}
