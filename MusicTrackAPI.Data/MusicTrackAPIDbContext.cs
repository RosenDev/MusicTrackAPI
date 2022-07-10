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

        public DbSet<User> Users { get; set; }


        public MusicTrackAPIDbContext()
        {

        }

        public MusicTrackAPIDbContext(DbContextOptions options) : base(options)
        {
  
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
      
            modelBuilder.HasCharSet("utf8");
  
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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInfoRules();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IEntity<int> &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IEntity<int>)entry.Entity;
                if (entry.State == EntityState.Modified && entity.UpdatedAt == null)
                {
                    entity.UpdatedAt = DateTime.UtcNow;
                } else if(entry.State == EntityState.Deleted && entity.DeletedAt == null) {
                    entity.DeletedAt = DateTime.UtcNow;
                    entity.IsDeleted = true;
                }
            }
        }
    }

