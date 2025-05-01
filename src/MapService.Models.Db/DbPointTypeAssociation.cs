using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHelper.MapService.Models.Db;
public class DbPointTypeAssociation
{
  public const string TableName = "PointTypeAssociations";

  public Guid Id { get; set; }
  public Guid PointTypeId { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsActive { get; set; }
  public DbPointType PointType { get; set; }
  public string Association { get; set; }
}
public class DbPointTypeAssociationConfiguration : IEntityTypeConfiguration<DbPointTypeAssociation>
{
  public void Configure(EntityTypeBuilder<DbPointTypeAssociation> builder)
  {
    builder
        .ToTable(DbPointTypeAssociation.TableName);

    builder
        .HasKey(x => x.Id);


    builder
        .HasOne(x => x.PointType)
        .WithMany(x => x.Associations);

  }
}