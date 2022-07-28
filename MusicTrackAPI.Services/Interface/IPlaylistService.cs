using System;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Playlist;
using MusicTrackAPI.Model.Track;

namespace MusicTrackAPI.Services.Interface
{
	public interface IPlaylistService : IDataService<Playlist, PlaylistModel>
	{
        Task<int> CreatePlaylistAsync(PlaylistCreateModel apiModel, CancellationToken ct);

        Task<int> UpdatePlaylistAsync(PlaylistUpdateModel apiModel, CancellationToken ct);

        Task<int> InsertTrackAsync(int playlistId, int position, int trackId, CancellationToken ct);

        Task<int> AddTrackAsync(int trackId, int playlistId, CancellationToken ct);

        Task<int> RemoveTrackAsync(int trackId, int playlistId, CancellationToken ct);
    }
}

