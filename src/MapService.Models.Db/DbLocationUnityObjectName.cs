using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HerzenHelper.MapService.Models.Db
{
    public class DbLocationUnityObjectName
    {
        public const string TableName = "LocationUnitySceneNames";

        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public string Locale { get; set; }
        public string ShortLocationName { get; set; }
        public string UnityObjectName { get; set; }
        public string? SwitchLocation { get; set; }

        public DbLocation Location { get; set; }
    }

    public class DbLocationUnityObjectNameConfiguration : IEntityTypeConfiguration<DbLocationUnityObjectName>
    {
        public void Configure(EntityTypeBuilder<DbLocationUnityObjectName> builder)
        {
            builder
              .ToTable(DbLocationUnityObjectName.TableName);

            builder
              .HasKey(c => c.Id);
        }
    }
}
