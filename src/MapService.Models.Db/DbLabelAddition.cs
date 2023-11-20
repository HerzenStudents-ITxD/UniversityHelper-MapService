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

public class DbLabelAddition
{
  public const string TableName = "LabelAddictions";

  public Guid Id { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsSuggested { get; set; }
  public bool IsActive { get; set; }

  public string Locale { get; set; }
  public string Name { get; set; }

  public DbLabel Label { get; set; }
}

public class DbLabelAdditionConfiguration : IEntityTypeConfiguration<DbLabelAddition>
{
  public void Configure(EntityTypeBuilder<DbLabelAddition> builder)
  {
    builder
        .ToTable(DbLableAddition.TableName);

    builder
        .HasKey(x => x.Id);


    builder
        .HasOne(x => x.Label)
        .WithMany(x => x.Additions);
  }
}
