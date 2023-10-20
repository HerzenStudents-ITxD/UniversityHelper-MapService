using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HerzenHelper.MapService.Models.Dto.Requests
{
    public record CreateLocationRequest
    {
        [Required]
        public List<int> Rights { get; set; }
    }
}
