﻿using Microsoft.EntityFrameworkCore;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories.Interfaces;

namespace MusicTrackAPI.Data.Repositories
{
    public class PlaylistRepository : RepositoryBase<Playlist>, IPlaylistRepository
	{
        public PlaylistRepository(MusicTrackAPIDbContext context) : base(context)
        {
        } 
    }
}

