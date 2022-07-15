using System;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;

namespace MusicTrackAPI.Services.Interface
{
	public interface IPlaylistService : IDataService<Playlist, PlaylistModel>
	{
    }
}

