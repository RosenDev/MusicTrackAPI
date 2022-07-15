using System;
using AutoMapper;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories;
using MusicTrackAPI.Data.Repositories.Interfaces;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Services
{
    public class AlbumService : DataService<Album, AlbumModel>, IAlbumService
    {
        private readonly IAlbumRepository albumRepository;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper) : base(albumRepository, mapper)
        {
            this.albumRepository = albumRepository;
        }
    }
}

