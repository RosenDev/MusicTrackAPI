using System;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MusicTrackAPI.Common;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories;
using MusicTrackAPI.Data.Repositories.Interfaces;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Playlist;
using MusicTrackAPI.Model.Track;
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

        public async Task<int> CreatePlaylistAsync(PlaylistCreateModel apiModel, CancellationToken ct)
        {
            if (apiModel.Duration.Hours > 2)
            {
                throw new InvalidOperationException(ErrorMessages.PlaylistPlayTimeExceedsTwoHours);
            }

            var playlist = mapper.Map<Playlist>(apiModel);

            playlist.AddTracks(apiModel.TracksIds);

            return (await playlistRepository.AddAsync(playlist, ct)).Id;

        }


        public async Task<int> InsertTrackAsync(int playlistId, int position, int trackId, CancellationToken ct)
        {
            var playlistEntity = await playlistRepository.FindAsync(playlistId, ct);

            var tracksInPlaylist = playlistEntity
              .TracksPlaylists
              .OrderBy(x => x.TrackPosition)
              .ToList();

            var entity = new TrackPlaylist
            {
                TrackId = trackId,
                PlaylistId = playlistId,
                TrackPosition = position
            };

           var existingRecordIndex = tracksInPlaylist.BinarySearch(entity);

            if(existingRecordIndex < 0)
            {
                throw new ArgumentException("The provided position is invalid! If you wish to add track istead of replacing one please use the AddTrack endpoint.");
            }

            tracksInPlaylist.Insert(existingRecordIndex, entity);

            for (int i = existingRecordIndex + 1; i < tracksInPlaylist.Count; i++)
            {
                ++tracksInPlaylist[i].TrackPosition;
            }

            return (await playlistRepository.UpdateAsync(playlistEntity, ct)).Id;
        }

        public async Task<int> UpdatePlaylistAsync(PlaylistUpdateModel apiModel, CancellationToken ct)
        {
            if (apiModel.Duration.Hours > 2)
            {
                throw new InvalidOperationException(ErrorMessages.PlaylistPlayTimeExceedsTwoHours);
            }

            var playlist = mapper.Map<Playlist>(apiModel);

            playlist.AddTracks(apiModel.TracksIds);

            return (await playlistRepository.UpdateAsync(playlist, ct)).Id;
        }

    }
}

