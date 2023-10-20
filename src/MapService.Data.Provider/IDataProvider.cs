using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.EFSupport.Provider;
using HerzenHelper.Core.Enums;
using HerzenHelper.MapService.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace HerzenHelper.MapService.Data.Provider
{
    [AutoInject(InjectType.Scoped)]
    public interface IDataProvider : IBaseDataProvider
    {
        DbSet<DbLocation> Locations { get; set; }
        DbSet<DbLocationAddition> LocationAdditions { get; set; }
        DbSet<DbLocationLabel> LocationLabels { get; set; }
        DbSet<DbLocationPhoto> LocationPhotos { get; set; }
        DbSet<DbLocationUnityPosition> LocationUnityPositions { get; set; }
        DbSet<DbLocationUnityObjectName> LocationUnityObjectName { get; set; }
        DbSet<DbRelation> Relations { get; set; }
    }
}
