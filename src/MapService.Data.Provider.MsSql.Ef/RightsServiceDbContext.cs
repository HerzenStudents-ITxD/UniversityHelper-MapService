﻿using System.Reflection;
using System.Threading.Tasks;
using HerzenHelper.MapService.Data.Provider;
using HerzenHelper.MapService.Models.Db;
using HerzenHelper.Core.EFSupport.Provider;
using Microsoft.EntityFrameworkCore;

namespace HerzenHelper.MapService.Data.Provider.MsSql.Ef
{
    public class MapServiceDbContext : DbContext, IDataProvider
    {
        public DbSet<DbLocation> Locations { get; set; }
        public DbSet<DbLocationAddition> LocationAdditions { get; set; }
        public DbSet<DbLocationLabel> LocationLabels { get; set; }
        public DbSet<DbLocationPhoto> LocationPhotos { get; set; }
        public DbSet<DbLocationUnityPosition> LocationUnityPositions { get; set; }
        public DbSet<DbLocationUnityObjectName> LocationUnityObjectName { get; set; }
        public DbSet<DbRelation> Relations { get; set; }
        public MapServiceDbContext(DbContextOptions<MapServiceDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("HerzenHelper.MapService.Models.Db"));
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
}
