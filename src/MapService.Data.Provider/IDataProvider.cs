using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.EFSupport.Provider;
using UniversityHelper.Core.Enums;
using UniversityHelper.MapService.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace UniversityHelper.MapService.Data.Provider;

[AutoInject(InjectType.Scoped)]
public interface IDataProvider : IBaseDataProvider
{
  public DbSet<DbLabel> Labels { get; set; }
  public DbSet<DbLabelAddition> LabelAdditions { get; set; }
  public DbSet<DbPointLabel> LabelLocations { get; set; }
  public DbSet<DbPoint> Locations { get; set; }
  public DbSet<DbLocationAddition> LocationAdditions { get; set; }
  public DbSet<DbPointPhoto> LocationPhotos { get; set; }
  public DbSet<DbLocationUnityObjectName> LocationUnityObjectNames { get; set; }
  public DbSet<DbLocationUnityPosition> LocationUnityPositions { get; set; }
  public DbSet<DbRelation> LocationUnityPositionRelations { get; set; }
  public DbSet<DbMap> Maps { get; set; }
  public DbSet<DbMapVersion> Versions { get; set; }
}
