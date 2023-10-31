using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int CreatedBy { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public bool IsActive { get; set; }
        public bool IsSuggested { get; set; }
        public bool InDevelop { get; set; }

        public ICollection<DbLocationAddition> Additions { get; set; }
        public ICollection<DbLocationLabel> Labels { get; set; }
        public ICollection<DbLocationPhoto> Photos { get; set; }
        public ICollection<DbLocationUnityObjectName> UnityObjectNames { get; set; }

        public DbLocation? ParentLocation { get; set; }
        public DbLocationUnityPosition? UnityPosition { get; set; }
        public DbServiceVersion ServiceVersion { get; set; }

        public DbLocation()
        {
            Additions = new HashSet<DbLocationAddition>();
            Labels = new HashSet<DbLocationLabel>();
            Photos = new HashSet<DbLocationPhoto>();
            UnityObjectNames = new HashSet<DbLocationUnityObjectName>();
        }
    }

    public class DbLocationConfiguration : IEntityTypeConfiguration<DbLocation>
    {
        public void Configure(EntityTypeBuilder<DbLocation> builder)
        {
            builder
                .ToTable(DbLocation.TableName);

            builder
                .HasKey(x => x.Id);


            builder
                .HasMany(x => x.Additions)
                .WithOne(x => x.Location);

            builder
                .HasMany(x => x.Labels)
                .WithOne(x => x.Location);

            builder
                .HasMany(x => x.Photos)
                .WithOne(x => x.Location);


            builder
                .HasMany(x => x.UnityObjectNames)
                .WithOne(x => x.Location);


            builder
                .HasOne(x => x.UnityPosition)
                .WithOne(x => x.Location)
                .HasForeignKey<DbLocationUnityPosition>(x => x.LocationId);
        }
    }
}
