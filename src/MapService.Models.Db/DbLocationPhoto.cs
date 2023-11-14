using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace UniversityHelper.MapService.Models.Db;

public class DbLocationPhoto
{
  public const string TableName = "LocationPhotos";

  public Guid Id { get; set; }
  public int CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsSuggested { get; set; }
  public bool IsActive { get; set; }

  public string Content { get; set; }
  public string Extension { get; set; }
  public int OrdinalNumber { get; set; }

  public DbLocation Location { get; set; }
}

public class DbLocationPhotoConfiguration : IEntityTypeConfiguration<DbLocationPhoto>
{
  public void Configure(EntityTypeBuilder<DbLocationPhoto> builder)
  {
    builder
        .ToTable(DbLocationPhoto.TableName);

    builder
        .HasKey(c => c.Id);


    builder
        .HasOne(x => x.Location)
        .WithMany(x => x.Photos);
  }
}
