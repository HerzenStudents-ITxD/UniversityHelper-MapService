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
