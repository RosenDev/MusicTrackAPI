using System;
using AutoMapper;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories;
using MusicTrackAPI.Data.Repositories.Interfaces;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Services
{
    public class PlaylistService : DataService<Playlist, PlaylistModel>, IPlaylistService
    {
        private readonly IPlaylistRepository playlistRepository;

        public PlaylistService(IPlaylistRepository playlistRepository, IMapper mapper) : base(playlistRepository, mapper)
        {
            this.playlistRepository = playlistRepository;
        }
    }
}

