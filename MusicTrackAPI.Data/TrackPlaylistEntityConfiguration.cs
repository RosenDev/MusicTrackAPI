using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicTrackAPI.Data.Domain;

namespace MusicTrackAPI.Data
{
    public class TrackPlaylistEntityConfiguration : BaseEntityConfiguration<TrackPlaylist>
    {

        public override void Configure(EntityTypeBuilder<TrackPlaylist> builder)
        {
            builder.HasIndex(x => x.TrackPosition)
                .IsUnique();

            builder.Property(x => x.TrackPosition)
                .ValueGeneratedOnAdd();
        }
    }
}

