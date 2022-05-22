using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicTrackAPI.Data.Domain;

namespace MusicTrackAPI.Data
{
    public class UserEntityConfiguration : BaseEntityConfiguration<User>
    {

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Username)
                .HasColumnType("varchar(255)");

            builder.Property(x => x.Password)
                .HasColumnType("varchar(255)");

            builder.HasIndex(x => x.Username).IsUnique();
        }
    }
}

