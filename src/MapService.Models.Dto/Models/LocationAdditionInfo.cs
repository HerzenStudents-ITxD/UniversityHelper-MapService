using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHelper.MapService.Models.Dto.Models;

public record LocationAdditionInfo
{
  public Guid Id { get; set; }
  public string Locale { get; set; }
  public string Name { get; set; }
  public string? Fact { get; set; }
  public string? Description { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public Guid? ModifiedBy { get; set; }
  public DateTime? ModifiedAtUtc { get; set; }
  public bool IsActive { get; set; }
}
