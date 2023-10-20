using HerzenHelper.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HerzenHelper.MapService.Models.Dto.Requests.Filters
{
    public record FindLocationFilter : BaseFindFilter
    {
        [FromQuery(Name = "includedeactivated")]
        public bool IncludeDeactivated { get; set; } = false;

        [FromQuery(Name = "locale")]
        public string Locale { get; set; }
    }
}
