using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HerzenHelper.MapService.Models.Db
{
    public class DbLocationPhoto
    {
        public const string TableName = "LocationPhotos";

        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public Guid PhotoId { get; set; }
        public int Number { get; set; }
        public bool IsActive { get; set; }

        public DbLocation Location { get; set; }
    }

    public class DbLocationPhotoConfiguration : IEntityTypeConfiguration<DbLocationPhoto>
    {
        public void Configure(EntityTypeBuilder<DbLocationPhoto> builder)
        {
            builder
            .ToTable(DbLocationPhoto.TableName);

            builder
            .HasKey(c => c.Id);

            builder
            .HasOne(ua => ua.Location)
            .WithMany(u => u.Photos);
        }
    }
}
