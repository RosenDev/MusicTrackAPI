using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicTrackAPI.Data.Domain.Interface;

namespace MusicTrackAPI.Data
{
    public class BaseEntityConfiguration<TEntity>: IEntityTypeConfiguration<TEntity> where TEntity: class, IEntity<int>
	{

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}

