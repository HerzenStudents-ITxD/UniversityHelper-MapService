using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.Attributes.ParseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniversityHelper.MapService.Models.Db;

public class DbPoint
{
  public const string TableName = "Points";

  public Guid Id { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsActive { get; set; }
  public float X { get; set; }
  public float Y { get; set; }
  public float Z { get; set; }
  public string Name { get; set; }
  public string? Fact { get; set; }
  public string? Description { get; set; }
  public string Icon { get; set; }
  [IgnoreParse]
  public ICollection<DbRelation> Relations { get; set; }
  [IgnoreParse]
  public ICollection<DbPointLabel> Labels { get; set; }
  [IgnoreParse]
  public ICollection<DbPointAssociation> Associations { get; set; }
  [IgnoreParse]
  public ICollection<DbPointPhoto> Photos { get; set; }
  [IgnoreParse]
  public ICollection<DbPointTypePoint> PointTypes { get; set; } 
  public DbPoint()
  {
    Relations = new HashSet<DbRelation>();
    Labels = new HashSet<DbPointLabel>();
    Associations = new HashSet<DbPointAssociation>();
    Photos = new HashSet<DbPointPhoto>();
    PointTypes = new HashSet<DbPointTypePoint>();
  }
}

public class DbPointConfiguration : IEntityTypeConfiguration<DbPoint>
{
  public void Configure(EntityTypeBuilder<DbPoint> builder)
  {
    builder
      .ToTable(DbPoint.TableName);

    builder
      .HasKey(x => x.Id);


    //builder
    //  .HasMany(x => x.Relations)
    //  .WithOne(x => x.Point);

    builder
      .HasMany(x => x.Labels)
      .WithOne(x => x.Point);
    
    builder
      .HasMany(x => x.Associations)
      .WithOne(x => x.Point);

    builder
      .HasMany(x => x.Photos)
      .WithOne(x => x.Point);
    builder
      .HasMany(p => p.PointTypes)
      .WithOne(t => t.Point);


  }
}
