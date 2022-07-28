using System;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Album;

namespace MusicTrackAPI.Services.Interface
{
	public interface IAlbumService : IDataService<Album, AlbumModel>
	{
        Task<int> CreateAlbumAsync(AlbumCreateModel apiModel, CancellationToken ct);

        Task<int> UpdateAlbumAsync(AlbumUpdateModel apiModel, CancellationToken ct);
    }
}

