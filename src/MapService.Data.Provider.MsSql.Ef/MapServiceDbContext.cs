using System.Reflection;
using System.Threading.Tasks;
using UniversityHelper.MapService.Data.Provider;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.Core.EFSupport.Provider;
using Microsoft.EntityFrameworkCore;

namespace UniversityHelper.MapService.Data.Provider.MsSql.Ef;

public class MapServiceDbContext : DbContext, IDataProvider
{
  public DbSet<DbLocation> Locations { get; set; }
  public DbSet<DbLocationAddition> LocationAdditions { get; set; }
  public DbSet<DbLocationLabel> LocationLabels { get; set; }
  public DbSet<DbLocationPhoto> LocationPhotos { get; set; }
  public DbSet<DbLocationUnityObjectName> LocationUnityObjectName { get; set; }
  public DbSet<DbLocationUnityPosition> LocationUnityPositions { get; set; }
  public DbSet<DbLocationUnityPositionRelation> LocationUnityPositionRelations { get; set; }
  public DbSet<DbServiceVersion> Versions { get; set; }
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
