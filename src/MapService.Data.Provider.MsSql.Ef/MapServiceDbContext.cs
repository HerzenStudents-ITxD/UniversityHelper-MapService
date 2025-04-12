using System.Reflection;
using System.Threading.Tasks;
using UniversityHelper.MapService.Data.Provider;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.Core.EFSupport.Provider;
using Microsoft.EntityFrameworkCore;

namespace UniversityHelper.MapService.Data.Provider.MsSql.Ef;

public class MapServiceDbContext : DbContext, IDataProvider
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
  public MapServiceDbContext(DbContextOptions<MapServiceDbContext> options) : base(options) { }


  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("UniversityHelper.MapService.Models.Db"));
  }

  public object MakeEntityDetached(object obj)
  {
    Entry(obj).State = EntityState.Detached;

    return Entry(obj).State;
  }

  void IBaseDataProvider.Save()
  {
    SaveChanges();
  }

  public void EnsureDeleted()
  {
    Database.EnsureDeleted();
  }

  public bool IsInMemory()
  {
    return Database.IsInMemory();
  }

  public async Task SaveAsync()
  {
    await SaveChangesAsync();
  }
}
