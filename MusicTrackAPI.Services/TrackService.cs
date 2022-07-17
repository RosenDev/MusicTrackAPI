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
    public class TrackService : DataService<Track, TrackModel>, ITrackService
    {
        private readonly ITrackRepository trackRepository;

        public TrackService(
            ITrackRepository trackRepository,
            IMapper mapper,
            ILogger<TrackService> logger) : base(trackRepository, mapper, logger)
        {
            this.trackRepository = trackRepository;
        }
    }
}

