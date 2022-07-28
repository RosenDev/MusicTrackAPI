using System;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories;
using MusicTrackAPI.Data.Repositories.Interfaces;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Album;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Services
{
    public class AlbumService : DataService<Album, AlbumModel>, IAlbumService
    {
        private readonly IAlbumRepository albumRepository;
        private readonly ITrackRepository trackRepository;

        public AlbumService(
            IAlbumRepository albumRepository,
            ITrackRepository trackRepository,

            IMapper mapper,
            ILogger<AlbumService> logger) : base(albumRepository, mapper, logger)
        {
            this.albumRepository = albumRepository;
            this.trackRepository = trackRepository;
        }


        public async Task<int> CreateAlbumAsync(AlbumCreateModel apiModel, CancellationToken ct)
        {
            var album = mapper.Map<Album>(apiModel);

            await repositoryBase.AddAsync(album, ct);

            foreach (var trackId in apiModel.TrackIds)
            {

                var track = await trackRepository.FindAsync(trackId, ct);

                track.AlbumId = album.Id;

                await trackRepository.UpdateAsync(track, ct);
            }

            return album.Id;
        }

        public async Task<int> UpdateAlbumAsync(AlbumUpdateModel apiModel, CancellationToken ct)
        {
            var album = mapper.Map<Album>(apiModel);

            await repositoryBase.UpdateAsync(album, ct);

            foreach (var trackId in apiModel.TrackIds)
            {

                var track = await trackRepository.FindAsync(trackId, ct);

                track.AlbumId = album.Id;

                await trackRepository.UpdateAsync(track, ct);
            }

            return album.Id;
        }
    }
}

