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

public class DbMap
{
  public const string TableName = "Maps";

  public Guid Id { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsActive { get; set; }

  public Guid UniversityId { get; set; }
  public Guid FileId { get; set; }


  public ICollection<DbMapVersion> Versions { get; set; }

  public DbMap()
  {
    Versions = new HashSet<DbMapVersion>();
  }
}

public class DbMapConfiguration : IEntityTypeConfiguration<DbMap>
{
  public void Configure(EntityTypeBuilder<DbMap> builder)
  {
    builder
        .ToTable(DbMap.TableName);

    builder
        .HasKey(x => x.Id);


    builder
      .HasMany(x => x.Versions)
      .WithOne(x => x.Map);
  }
}
