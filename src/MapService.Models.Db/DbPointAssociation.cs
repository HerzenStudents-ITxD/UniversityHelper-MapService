using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHelper.MapService.Models.Db;
public class DbPointAssociation
{
  public const string TableName = "PointAssociations";

  public Guid Id { get; set; }
  public Guid PointId { get; set; }
  public DbPoint Point { get; set; }
  public string Association { get; set; }

}
public class DbPointAssociationConfiguration : IEntityTypeConfiguration<DbPointAssociation>
{
  public void Configure(EntityTypeBuilder<DbPointAssociation> builder)
  {
    builder
        .ToTable(DbPointAssociation.TableName);

    builder
        .HasKey(x => x.Id);


    builder
        .HasOne(x => x.Point)
        .WithMany(x => x.Associations);
  }
}