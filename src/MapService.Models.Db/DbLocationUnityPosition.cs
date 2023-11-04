using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace HerzenHelper.MapService.Models.Db
{
    public class DbLocationUnityPosition
    {
        public const string TableName = "UnityPositions";

        public Guid Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public bool IsSuggested { get; set; }
        public bool IsActive { get; set; }

        public Guid LocationId { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public ICollection<DbLocationUnityPositionRelation> Relations { get; set; }

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
