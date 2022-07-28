using AutoMapper;
using Microsoft.Extensions.Logging;
using MusicTrackAPI.Common;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories.Interfaces;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Playlist;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Services
{
    public class PlaylistService : DataService<Playlist, PlaylistModel>, IPlaylistService
    {
        private readonly IPlaylistRepository playlistRepository;
        private readonly ITrackRepository trackRepository;

        public PlaylistService(
            IPlaylistRepository playlistRepository,
            ITrackRepository trackRepository,
            IMapper mapper,
            ILogger<PlaylistService> logger) : base(playlistRepository, mapper, logger)
        {
            this.playlistRepository = playlistRepository;
            this.trackRepository = trackRepository;
        }

        public async Task<int> CreatePlaylistAsync(PlaylistCreateModel apiModel, CancellationToken ct)
        {
            var playlist = mapper.Map<Playlist>(apiModel);

            if (apiModel.TracksIds.Count == 0)
            {
                throw new InvalidOperationException(ErrorMessages.PlaylistContainsNoTracks);
            }

            var totalDuration = await trackRepository.GetTotalTracksDurationAsync(apiModel.TracksIds, ct);

            playlist.Duration = totalDuration;

            if (playlist.Duration.TotalHours > 2)
            {
                throw new InvalidOperationException(ErrorMessages.PlaylistPlayTimeExceedsTwoHours);
            }

            await playlistRepository.AddAsync(playlist, ct);

            playlist.AddTracks(apiModel.TracksIds);

            return (await playlistRepository.UpdateAsync(playlist, ct)).Id;
        }


        public async Task<int> AddTrackAsync(int trackId, int playlistId, CancellationToken ct)
        {
            var playlist = await playlistRepository.FindAsync(playlistId, ct);

            playlist.AddTracks(new List<int> { trackId });

            return (await playlistRepository.UpdateAsync(playlist, ct)).Id;
        }

        public async Task<int> RemoveTrackAsync(int trackId, int playlistId, CancellationToken ct)
        {
            var playlist = await playlistRepository.FindAsync(playlistId, ct);

            playlist.RemoveTrack(trackId);

            return (await playlistRepository.UpdateAsync(playlist, ct)).Id;
        }

        public async Task<int> InsertTrackAsync(int playlistId, int position, int trackId, CancellationToken ct)
        {
            var playlistEntity = await playlistRepository.FindAsync(playlistId, ct);

            if (playlistEntity == null)
            {
                throw new ArgumentNullException(ErrorMessages.PlaylistNotFound);
            }

            var tracksInPlaylist = playlistEntity
              .TracksPlaylists
              .ToList();


            tracksInPlaylist.Sort(new TrackPlaylistComparer());

            var entity = new TrackPlaylist
            {
                TrackId = trackId,
                PlaylistId = playlistId,
                TrackPosition = position
            };

            var existingRecordIndex = tracksInPlaylist.BinarySearch(entity, new TrackPlaylistComparer());

            if (existingRecordIndex < 0)
            {
                throw new ArgumentException(ErrorMessages.InvalidPosition);
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

            var playlist = mapper.Map<Playlist>(apiModel);

            if (playlist.Duration.TotalHours > 2)
            {
                throw new InvalidOperationException(ErrorMessages.PlaylistPlayTimeExceedsTwoHours);
            }

            playlist.AddTracks(apiModel.TracksIds);

            var totalDuration = await trackRepository.GetTotalTracksDurationAsync(playlist.TracksPlaylists.Select(x => x.TrackId).ToList(), ct);

            playlist.Duration = totalDuration;


            return (await playlistRepository.UpdateAsync(playlist, ct)).Id;
        }

    }
}

