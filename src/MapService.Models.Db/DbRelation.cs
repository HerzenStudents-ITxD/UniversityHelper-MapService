using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace UniversityHelper.MapService.Models.Db;

public class DbRelation
{
  public const string TableName = "Relations";

  public Guid Id { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }

  public Guid FirstPointId { get; set; }
  public DbPoint FirstPoint { get; set; }
  public Guid SecondPointId { get; set; }
  public DbPoint SecondPoint { get; set; }
}

public class DbRelationConfiguration : IEntityTypeConfiguration<DbRelation>
{
  public void Configure(EntityTypeBuilder<DbRelation> builder)
  {
    builder
        .ToTable(DbRelation.TableName);

    builder
        .HasKey(c => c.Id);

    builder
        .HasOne(ars => ars.FirstPoint)
        .WithMany()
        .OnDelete(DeleteBehavior.Restrict);

    builder
        .HasOne(ars => ars.SecondPoint)
        .WithMany()
        .OnDelete(DeleteBehavior.Restrict);
  }
}
