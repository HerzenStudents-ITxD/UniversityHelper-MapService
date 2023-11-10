using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.EFSupport.Provider;
using UniversityHelper.Core.Enums;
using UniversityHelper.MapService.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace UniversityHelper.MapService.Data.Provider
{
    [AutoInject(InjectType.Scoped)]
    public interface IDataProvider : IBaseDataProvider
    {
        public DbSet<DbLocation> Locations { get; set; }
        public DbSet<DbLocationAddition> LocationAdditions { get; set; }
        public DbSet<DbLocationLabel> LocationLabels { get; set; }
        public DbSet<DbLocationPhoto> LocationPhotos { get; set; }
        public DbSet<DbLocationUnityObjectName> LocationUnityObjectName { get; set; }
        public DbSet<DbLocationUnityPosition> LocationUnityPositions { get; set; }
        public DbSet<DbLocationUnityPositionRelation> LocationUnityPositionRelations { get; set; }
        public DbSet<DbServiceVersion> Versions { get; set; }
    }
}
