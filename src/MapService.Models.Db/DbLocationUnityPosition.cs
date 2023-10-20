using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HerzenHelper.MapService.Models.Db
{
    public class DbLocationUnityPosition
    {
        public const string TableName = "LocationUnityPositions";
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAtUtc { get; set; }

        public DbLocation Location { get; set; }
    }

    public class DbLocationUnityPositionConfiguration : IEntityTypeConfiguration<DbLocationUnityPosition>
    {
        public void Configure(EntityTypeBuilder<DbLocationUnityPosition> builder)
        {
            builder
              .ToTable(DbLocationUnityPosition.TableName);

            builder
              .HasKey(c => c.Id);
        }
    }
}
