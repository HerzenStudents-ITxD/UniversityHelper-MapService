using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHelper.MapService.Models.Dto.Models;

public record PointPhotoInfo
{
  public Guid Id { get; set; }
  public Guid PhotoId { get; set; }
  public int Number { get; set; }
  public bool IsActive { get; set; }
}
