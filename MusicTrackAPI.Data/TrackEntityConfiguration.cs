using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicTrackAPI.Data.Domain;

namespace MusicTrackAPI.Data
{
    public class TrackEntityConfiguration : BaseEntityConfiguration<Track>
    {

        public override void Configure(EntityTypeBuilder<Track> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(255)");

            builder.Property(x => x.WrittenBy)
                .HasColumnType("varchar(255)");

            builder.Property(x => x.ArrangedBy)
                .HasColumnType("varchar(255)");


            builder.HasIndex(x => new { x.ArrangedBy, x.PerformedBy, x.Name, x.Type });
        }
    }
}

