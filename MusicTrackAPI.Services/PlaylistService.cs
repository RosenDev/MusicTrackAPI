using System;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MusicTrackAPI.Common;
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

        public override Task<int> CreateAsync(PlaylistModel apiModel, CancellationToken ct)
        {
            if(apiModel.Duration.Hours > 2)
            {
                throw new InvalidOperationException(ErrorMessages.PlaylistPlayTimeExceedsTwoHours);
            }

            return base.CreateAsync(apiModel, ct);
        }

        public override Task<int> UpdateAsync(PlaylistModel apiModel, CancellationToken ct)
        {
            if (apiModel.Duration.Hours > 2)
            {
                throw new InvalidOperationException(ErrorMessages.PlaylistPlayTimeExceedsTwoHours);
            }

            return base.UpdateAsync(apiModel, ct);
        }
    }
}

