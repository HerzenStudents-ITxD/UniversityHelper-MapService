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
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsActive { get; set; }
  public DbPointType PointType { get; set; }
  public float XMin { get; set; }
  public float YMin { get; set; }
  public float ZMin { get; set; }
  public float XMax { get; set; }
  public float YMax { get; set; }
  public float ZMax { get; set; }
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