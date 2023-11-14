using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.Attributes.ParseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniversityHelper.MapService.Models.Db;

public class DbLocationLabel
{
  public const string TableName = "LocationLabels";

  public Guid Id { get; set; }
  public int CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsSuggested { get; set; }
  public bool IsActive { get; set; }

  public string Locale { get; set; }
  public string Name { get; set; }

  public DbLocation Location { get; set; }
}

public class DbLocationLabelConfiguration : IEntityTypeConfiguration<DbLocationLabel>
{
  public void Configure(EntityTypeBuilder<DbLocationLabel> builder)
  {
    builder
        .ToTable(DbLocationLabel.TableName);

    builder
        .HasKey(x => x.Id);


    builder
        .HasOne(x => x.Location)
        .WithMany(x => x.Labels);
  }
}
