using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicTrackAPI.Data.Domain;

namespace MusicTrackAPI.Data
{
    public class PlaylistEntityConfiguration : BaseEntityConfiguration<Playlist>
    {

        public override void Configure(EntityTypeBuilder<Playlist> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.TrackName)
                .HasColumnType("varchar(255)");

            builder.Property(x => x.AlbumName)
                .HasColumnType("varchar(255)");

            builder.Property(x => x.Name)
                .HasColumnType("varchar(255)");

            builder.HasIndex(x => new { x.CreatedAt, x.Name});

        }
    }
}

