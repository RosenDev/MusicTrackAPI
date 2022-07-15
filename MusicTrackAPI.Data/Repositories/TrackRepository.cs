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
    }
}

