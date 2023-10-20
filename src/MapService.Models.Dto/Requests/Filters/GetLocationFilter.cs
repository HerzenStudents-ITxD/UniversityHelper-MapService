using Microsoft.AspNetCore.Mvc;
using System;

namespace HerzenHelper.MapService.Models.Dto.Requests.Filters
{
    public record GetLocationFilter
    {
        [FromQuery(Name = "roleid")]
        public Guid RoleId { get; set; }

        [FromQuery(Name = "locale")]
        public string Locale { get; set; }
    }
}
