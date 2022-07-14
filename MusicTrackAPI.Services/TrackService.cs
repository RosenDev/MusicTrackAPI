using System;
using AutoMapper;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Services
{
    public class TrackService : DataService<Track, TrackModel>, ITrackService
    {
        private readonly IUserRepository userRepository;

        public TrackService(ITrackRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
            this.userRepository = userRepository;
        }
    }
}

