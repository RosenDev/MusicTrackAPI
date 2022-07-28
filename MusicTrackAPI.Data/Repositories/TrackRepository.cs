using Microsoft.EntityFrameworkCore;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories.Interfaces;

namespace MusicTrackAPI.Data.Repositories
{
    public class TrackRepository : RepositoryBase<Track>, ITrackRepository
	{
        public TrackRepository(MusicTrackAPIDbContext context) : base(context)
        {
        }


        protected override IQueryable<Track> ApplyInclude(IQueryable<Track> query)
        {
            return query.Include(x => x.Album)
                .Include(x => x.TracksPlaylists)
                .ThenInclude(x => x.Playlist);
        }

        public async Task<TimeSpan> GetTotalTracksDurationAsync(List<int> ids, CancellationToken ct)
        {
            return new TimeSpan((await Set.Where(x => ids.Any(id => id == x.Id)).ToListAsync(ct)).Sum(x => x.Duration.Ticks));
        }
    }
}

