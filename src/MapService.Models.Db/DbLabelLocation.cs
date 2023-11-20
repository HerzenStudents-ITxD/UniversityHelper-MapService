using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.Attributes.ParseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniversityHelper.MapService.Models.Db;

public class DbLabelLocation
{
  public const string TableName = "LabelLocations";

  public Guid Id { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsSuggested { get; set; }
  public bool IsActive { get; set; }

  public Guid LabelId { get; set; }
  public DbLabel Label { get; set; }
  public Guid LocationId { get; set; }
  public DbLocation Location { get; set; }
}

public class DbLocationLabelConfiguration : IEntityTypeConfiguration<DbLabelLocation>
{
  public void Configure(EntityTypeBuilder<DbLabelLocation> builder)
  {
    builder
        .ToTable(DbLabelLocation.TableName);

    builder
        .HasKey(x => x.Id);


    builder
        .HasOne(x => x.Location)
        .WithMany(x => x.Labels);
  }
}
