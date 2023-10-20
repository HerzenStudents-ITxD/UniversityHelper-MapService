using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HerzenHelper.MapService.Models.Db
{
    public class DbRelation
    {
        public const string TableName = "Relations";
        public Guid Id { get; set; }
        public Guid StartPositionId { get; set; }
        public Guid EndPositionId { get; set; }

        public DbLocationUnityPosition StartPosition { get; set; }
        public DbLocationUnityPosition EndPosition { get; set; }
    }

    public class DbRelationConfiguration : IEntityTypeConfiguration<DbRelation>
    {
        public void Configure(EntityTypeBuilder<DbRelation> builder)
        {
            builder
              .ToTable(DbRelation.TableName);

            builder
              .HasKey(c => c.Id);
        }
    }
}
