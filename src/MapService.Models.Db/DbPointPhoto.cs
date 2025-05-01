using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace UniversityHelper.MapService.Models.Db;

public class DbPointPhoto
{
  public const string TableName = "Photos";

  public Guid Id { get; set; }
  public Guid PointId { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsActive { get; set; }
  public string Content { get; set; }
  public int OrdinalNumber { get; set; }

  public DbPoint Point { get; set; }
}

public class DbPointPhotoConfiguration : IEntityTypeConfiguration<DbPointPhoto>
{
  public void Configure(EntityTypeBuilder<DbPointPhoto> builder)
  {
    builder
        .ToTable(DbPointPhoto.TableName);

    builder
        .HasKey(c => c.Id);


    builder
        .HasOne(x => x.Point)
        .WithMany(x => x.Photos);
  }
}
