using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace UniversityHelper.MapService.Models.Db;

public class DbLocationUnityObjectName
{
  public const string TableName = "UnitySceneNames";

  public Guid Id { get; set; }
  public int CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsSuggested { get; set; }
  public bool IsActive { get; set; }

  public string Locale { get; set; }
  public string ShortLocationName { get; set; }
  public string UnityObjectName { get; set; }

  public DbLocation Location { get; set; }
}

public class DbLocationUnityObjectNameConfiguration : IEntityTypeConfiguration<DbLocationUnityObjectName>
{
  public void Configure(EntityTypeBuilder<DbLocationUnityObjectName> builder)
  {
    builder
        .ToTable(DbLocationUnityObjectName.TableName);

    builder
        .HasKey(c => c.Id);


    builder
        .HasOne(x => x.Location)
        .WithMany(x => x.UnityObjectNames);
  }
}
