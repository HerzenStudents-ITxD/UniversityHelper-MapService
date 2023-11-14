using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHelper.MapService.Models.Dto.Models;

public record RelationInfo
{
  public Guid Id { get; set; }
  public Guid StartPositionId { get; set; }
  public Guid EndPositionId { get; set; }
}
