using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHelper.MapService.Models.Dto.Models;

public record UnityObjectNameInfo
{
  public Guid Id { get; set; }
  public string Locale { get; set; }
  public string ShortPointName { get; set; }
  public string UnityObjectName { get; set; }
  public string? SwitchPoint { get; set; }
}
