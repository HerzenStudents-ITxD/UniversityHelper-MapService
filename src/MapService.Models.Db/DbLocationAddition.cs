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
    public class DbLocationAddition
    {
        public const string TableName = "LocationAddictions";
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public string Locale { get; set; }
        public string Name { get; set; }
        public string? Fact { get; set; }
        public string? Description { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedAtUtc { get; set; }
        public bool IsActive { get; set; }


        public DbLocation Location { get; set; }
    }

    public class DbLocationAdditionConfiguration : IEntityTypeConfiguration<DbLocationAddition>
    {
        public void Configure(EntityTypeBuilder<DbLocationAddition> builder)
        {
            builder
              .ToTable(DbLocationAddition.TableName);

            builder
              .HasKey(x => x.Id);
        }
    }
}
