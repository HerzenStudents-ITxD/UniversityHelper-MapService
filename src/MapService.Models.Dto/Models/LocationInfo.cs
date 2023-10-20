using System;
using System.Collections.Generic;

namespace HerzenHelper.MapService.Models.Dto.Models
{
    public record LocationInfo
    {
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<LocationLabelInfo> Labels { get; set; }
    }
}
