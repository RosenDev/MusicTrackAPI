using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicTrackAPI.Data.Domain;

namespace MusicTrackAPI.Data
{
    public class AlbumEntityConfiguration : BaseEntityConfiguration<Album>
    {

        public override void Configure(EntityTypeBuilder<Album> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(255)");

            builder.HasIndex(x => new { x.Name, x.PublishingYear, x.Duration });
        }
    }
}

