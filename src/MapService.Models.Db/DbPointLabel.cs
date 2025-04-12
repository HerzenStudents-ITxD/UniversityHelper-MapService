using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.Attributes.ParseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniversityHelper.MapService.Models.Db;

public class DbPointLabel
{
  public const string TableName = "LabelPoints";

  public Guid Id { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  
  public bool IsActive { get; set; }

  public Guid LabelId { get; set; }
  public DbLabel Label { get; set; }
  public Guid PointId { get; set; }
  public DbPoint Point { get; set; }
}

public class DbPointLabelConfiguration : IEntityTypeConfiguration<DbPointLabel>
{
  public void Configure(EntityTypeBuilder<DbPointLabel> builder)
  {
    builder
        .ToTable(DbPointLabel.TableName);

    builder
        .HasKey(x => x.Id);


    builder
        .HasOne(x => x.Label)
        .WithMany(x => x.Points);
    builder
    .HasOne(x => x.Point)
    .WithMany(x => x.Labels);
  }
}
