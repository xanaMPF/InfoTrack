using System;
using System.Collections.Generic;

#nullable disable

namespace Scraper.Infrastructure.Models
{
    public partial class SearchHistory
    {
        public int Id { get; set; }
        public string Keywords { get; set; }
        public int SearchEngineId { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
        public string Result { get; set; }

        public virtual SearchEngine SearchEngine { get; set; }
    }
}
