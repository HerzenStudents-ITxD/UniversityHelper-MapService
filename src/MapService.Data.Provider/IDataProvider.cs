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
  public DbSet<DbPoint> Points { get; set; }
  public DbSet<DbPointAssociation> PointAssociations { get; set; }
  public DbSet<DbPointLabel> PointLabels { get; set; }
  public DbSet<DbPointPhoto> PointPhotos { get; set; }
  public DbSet<DbPointType> PointTypes { get; set; }
  public DbSet<DbPointTypeAssociation> PointTypeAssociations { get; set; }
  public DbSet<DbPointTypeRectangularParallelepiped> PointTypeRectangularParallelepipeds { get; set; }
  public DbSet<DbRelation> Relations { get; set; }

}
