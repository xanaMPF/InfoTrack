using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Scraper.Domain.DTOs
{
    public class SearchRequestDTO : SearchRequestBaseDTO
    {
        public IEnumerable<SearchEngineBaseDTO> SearchEngines { get; set; }

        public List<int> SearchEngineIds => SearchEngines.Select(x => x.Id).ToList();

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResult = base.Validate(validationContext).ToList();
            
            if (SearchEngines == null || SearchEngines.Count() == 0)
            {
                validationResult.Add(new ValidationResult("There must be at least one Search Engine"));
            }

            return validationResult;
        }
    }
}
