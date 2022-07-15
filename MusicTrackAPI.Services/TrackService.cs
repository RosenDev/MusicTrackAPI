using System;
using AutoMapper;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories;
using MusicTrackAPI.Data.Repositories.Interfaces;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Services
{
    public class TrackService : DataService<Track, TrackModel>, ITrackService
    {
        private readonly ITrackRepository trackRepository;

        public TrackService(ITrackRepository trackRepository, IMapper mapper) : base(trackRepository, mapper)
        {
            this.trackRepository = trackRepository;
        }
    }
}

