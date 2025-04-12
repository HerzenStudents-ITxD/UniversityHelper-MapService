using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHelper.MapService.Models.Db;
public class DbPointTypeRectangularParallelepiped
{
  public const string TableName = "PointTypeRectangularParallelepipeds";

  public Guid Id { get; set; }
  public Guid PointTypeId { get; set; }
  public DbPointType PointType { get; set; }
  public float X1 { get; set; }
  public float Y1 { get; set; }
  public float Z1 { get; set; }
  public float X2 { get; set; }
  public float Y2 { get; set; }
  public float Z2 { get; set; }
}
public class DbPointTypeRectangularParallelepipedConfiguration : IEntityTypeConfiguration<DbPointTypeRectangularParallelepiped>
{
  public void Configure(EntityTypeBuilder<DbPointTypeRectangularParallelepiped> builder)
  {
    builder
        .ToTable(DbPointTypeRectangularParallelepiped.TableName);

    builder
        .HasKey(x => x.Id);
    
    builder
        .HasOne(x => x.PointType)
        .WithMany(x => x.Parallelepipeds);
  }
}