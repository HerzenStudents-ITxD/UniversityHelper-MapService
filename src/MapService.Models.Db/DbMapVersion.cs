using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace UniversityHelper.MapService.Models.Db;

public class DbMapVersion
{
  public const string TableName = "MapVersions";

  public int Number { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsActive { get; set; }
  
  public DbMap Map { get; set; }
  public ICollection<DbLocation> Locations { get; set; }

  public DbMapVersion()
  {
    Locations = new HashSet<DbLocation>();
  }

}

public class DbServiceVersionConfiguration : IEntityTypeConfiguration<DbMapVersion>
{
  public void Configure(EntityTypeBuilder<DbMapVersion> builder)
  {
    builder
      .ToTable(DbMap.TableName);

    builder
      .HasKey(p => p.Number);
    

    builder
      .HasOne(x => x.Map)
      .WithMany(x => x.Versions);

    builder
      .HasMany(x => x.Locations)
      .WithOne(x => x.MapVersion);
  }
}
