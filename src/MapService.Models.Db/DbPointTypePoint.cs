using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHelper.MapService.Models.Db;
public class DbPointTypePoint
{
  public const string TableName = "PointTypePoints";

  public Guid Id { get; set; }
  public Guid PointTypeId { get; set; }
  public DbPointType PointType { get; set; }
  public Guid PointId { get; set; }
  public DbPoint Point { get; set; }
}
public class DbPointTypePointConfiguration : IEntityTypeConfiguration<DbPointTypePoint>
{
  public void Configure(EntityTypeBuilder<DbPointTypePoint> builder)
  {
    builder
      .ToTable(DbPointTypePoint.TableName);

    builder
      .HasKey(x => x.Id);
    builder
      .HasOne(x => x.PointType)
      .WithMany(p => p.Points);
    builder
      .HasOne(x => x.Point)
      .WithMany(p => p.PointTypes);
  }
}
