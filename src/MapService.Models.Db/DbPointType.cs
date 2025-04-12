using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.Attributes.ParseEntity;

namespace UniversityHelper.MapService.Models.Db;
public class DbPointType
{
  public const string TableName = "PointTypes";
  public Guid Id { get; set; }
  public string Icon { get; set; }

  [IgnoreParse]
  public ICollection<DbPointTypeAssociation> Associations { get; set; }
  [IgnoreParse]
  public ICollection<DbPointTypeRectangularParallelepiped> Parallelepipeds { get; set; }
  [IgnoreParse]
  public ICollection<DbPointTypePoint> Points { get; set; }
  public DbPointType()
  {
    Associations = new HashSet<DbPointTypeAssociation>();
    Parallelepipeds = new HashSet<DbPointTypeRectangularParallelepiped>();
    Points = new HashSet<DbPointTypePoint>();
  }
}
public class DbPointTypeConfiguration : IEntityTypeConfiguration<DbPointType>
{
  public void Configure(EntityTypeBuilder<DbPointType> builder)
  {
    builder
        .ToTable(DbPointType.TableName);

    builder
        .HasKey(x => x.Id);


    builder
        .HasMany(x => x.Associations)
        .WithOne(x => x.PointType);
    builder
        .HasMany(x => x.Parallelepipeds)
        .WithOne(x => x.PointType);

    builder
      .HasMany(x => x.Points)
      .WithOne(x=> x.PointType);
  }
}