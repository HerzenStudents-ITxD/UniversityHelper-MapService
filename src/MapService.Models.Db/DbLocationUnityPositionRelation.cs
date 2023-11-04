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
    public class DbLocationUnityPositionRelation
    {
        public const string TableName = "LocationUnityPositionRelations";

        public Guid Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public bool IsActive { get; set; }

        public Guid FirstPositionId { get; set; }
        public DbLocationUnityPosition FirstPosition { get; set; }
        public Guid SecondPositionId { get; set; }
        public DbLocationUnityPosition SecondPosition { get; set; }
    }

    public class DbLocationUnityPositionRelationConfiguration : IEntityTypeConfiguration<DbLocationUnityPositionRelation>
    {
        public void Configure(EntityTypeBuilder<DbLocationUnityPositionRelation> builder)
        {
            builder
                .ToTable(DbLocationUnityPositionRelation.TableName);

            builder
                .HasKey(c => c.Id);

            builder
                .HasOne(ars => ars.FirstPosition)
                .WithOne()
                .HasForeignKey<DbLocationUnityPositionRelation>(ars => ars.FirstPositionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ars => ars.SecondPosition)
                .WithOne()
                .HasForeignKey<DbLocationUnityPositionRelation>(ars => ars.SecondPositionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
