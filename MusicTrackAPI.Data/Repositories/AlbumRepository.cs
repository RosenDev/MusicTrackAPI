using Microsoft.EntityFrameworkCore;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories.Interfaces;

namespace MusicTrackAPI.Data.Repositories
{
    public class AlbumRepository : RepositoryBase<Album>, IAlbumRepository
	{
        public AlbumRepository(MusicTrackAPIDbContext context) : base(context)
        {
        }

        protected override IQueryable<Album> ApplyInclude(IQueryable<Album> query)
        {
            return query.Include(x => x.Playlists)
                .Include(x => x.Tracks);
        }
    }
}

