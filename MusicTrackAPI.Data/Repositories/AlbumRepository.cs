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
    }
}

