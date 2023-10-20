using System.Collections.Generic;
using HerzenHelper.MapService.Models.Dto.Models;

namespace HerzenHelper.MapService.Models.Dto.Responses
{
    public record LocationResponse
    {
        public LocationInfo Role { get; set; }
    }
}
