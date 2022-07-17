using System;
using AutoMapper;
using Microsoft.Extensions.Logging;
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

        public PlaylistService(
            IPlaylistRepository playlistRepository,
            IMapper mapper,
            ILogger<PlaylistService> logger) : base(playlistRepository, mapper, logger)
        {
            this.playlistRepository = playlistRepository;
        }
    }
}

