using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerzenHelper.Core.BrokerSupport.Attributes.ParseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HerzenHelper.MapService.Models.Db
{
    public class DbLocation
    {
        public const string TableName = "Locations";

        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public bool IsActive { get; set; }


        [IgnoreParse]
        public DbLocation? ParentLocation { get; set; }
        [IgnoreParse]
        public ICollection<DbLocationUnityPosition> UnityPositions { get; set; }
        [IgnoreParse]
        public ICollection<DbLocationAddition> Additions { get; set; }
        [IgnoreParse]
        public ICollection<DbLocationPhoto> Photos { get; set; }
        [IgnoreParse]
        public DbLocationUnityPosition? UnityPosition { get; set; }
        [IgnoreParse]
        public DbLocationUnityObjectName? UnityObjectName { get; set; }

        public DbLocation()
        {
            UnityPositions = new HashSet<DbLocationUnityPosition>();
            Additions = new HashSet<DbLocationAddition>();
            Photos = new HashSet<DbLocationPhoto>();
        }
    }

    public class DbLocationConfiguration : IEntityTypeConfiguration<DbLocation>
    {
        public void Configure(EntityTypeBuilder<DbLocation> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasMany(u => u.UnityPositions)
                .WithOne(ua => ua.Location);

            builder
                .HasMany(u => u.Additions)
                .WithOne(ua => ua.Location);

            builder
                .HasMany(u => u.Photos)
                .WithOne(ua => ua.Location);
        }
    }
}
