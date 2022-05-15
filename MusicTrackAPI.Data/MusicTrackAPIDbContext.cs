using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Domain.Interface;

namespace MusicTrackAPI.Data;
public class MusicTrackAPIDbContext: DbContext
{

    public DbSet<Track> Tracks { get; set; }

    public DbSet<Album> Albums { get; set; }

    public DbSet<Playlist> Playlists { get; set; }


    public MusicTrackAPIDbContext()
    {

    }

    public MusicTrackAPIDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);


        //Only for migrations
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=127.0.0.1; Port=3306; Database=music_track_api; Uid=yourUserHere; Pwd=yourPassHere;";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(IDeletable).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "p");
                var deletedCheck = Expression.Lambda(Expression.Equal(Expression.Property(parameter, "IsDeleted"), Expression.Constant(false)), parameter);
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(deletedCheck);
            }
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MusicTrackAPIDbContext).Assembly);
    }
}

