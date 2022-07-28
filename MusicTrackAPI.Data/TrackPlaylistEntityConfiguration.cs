using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.ValueGenerators;

namespace MusicTrackAPI.Data
{
    public class TrackPlaylistEntityConfiguration : BaseEntityConfiguration<TrackPlaylist>
    {

        public override void Configure(EntityTypeBuilder<TrackPlaylist> builder)
        {
            builder.Property(x => x.TrackPosition)
                .HasValueGenerator(typeof(TrackPositionValueGenerator))
                .ValueGeneratedOnAdd();    
        }
    }
}

