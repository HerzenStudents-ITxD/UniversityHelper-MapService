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

public class DbLabel
{
  public const string TableName = "Labels";

  public Guid Id { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsActive { get; set; }
  public string Name { get; set; }
  [IgnoreParse]
  public ICollection<DbPointLabel> Points { get; set; }

  public DbLabel()
  {
    Points = new HashSet<DbPointLabel>();
  }
}

public class DbLabelConfiguration : IEntityTypeConfiguration<DbLabel>
{
  public void Configure(EntityTypeBuilder<DbLabel> builder)
  {
    builder
        .ToTable(DbLabel.TableName);

    builder
        .HasKey(x => x.Id);


    builder
      .HasMany(x => x.Points)
      .WithOne(x => x.Label);
  }
}
