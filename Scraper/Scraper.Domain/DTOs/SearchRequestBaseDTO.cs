using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Scraper.Domain.DTOs
{
    public class SearchRequestBaseDTO : IValidatableObject
    {
        public string Keywords { get; set; }

        public string Url { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResult = new List<ValidationResult>();
            if (String.IsNullOrEmpty(Keywords))
            {
                validationResult.Add(new ValidationResult("Keywords can't be empty"));
            }

            if (String.IsNullOrEmpty(Url))
            {
                validationResult.Add(new ValidationResult("Url can't be empty"));
            }

            return validationResult;
        }
    }
}
