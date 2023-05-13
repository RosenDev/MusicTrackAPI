using AutoMapper;
using Microsoft.Extensions.Logging;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories.Interfaces;
using MusicTrackAPI.Model.Track;
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

        public async Task<int> CreateTrackAsync(TrackCreateModel createTrackModel, CancellationToken ct)
        {
            var entity = mapper.Map<Track>(createTrackModel);

            return (await trackRepository.AddAsync(entity, ct)).Id;
        }

        public async Task<int> UpdateTrackAsync(TrackUpdateModel updateTrackModel, CancellationToken ct)
        {
            var entity = mapper.Map<Track>(updateTrackModel);

            return (await trackRepository.UpdateAsync(entity, ct)).Id;
        }
    }
}

