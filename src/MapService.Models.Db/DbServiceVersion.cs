using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace UniversityHelper.MapService.Models.Db;

public class DbServiceVersion
{
  public const string TableName = "ServiceVersions";

  public int Number { get; set; }
  public int CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsActive { get; set; }
}

public class DbServiceVersionConfiguration : IEntityTypeConfiguration<DbServiceVersion>
{
  public void Configure(EntityTypeBuilder<DbServiceVersion> builder)
  {
    builder
        .HasKey(p => p.Number);
  }
}
