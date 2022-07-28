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
    public class UserService : DataService<User, UserModel>, IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            ILogger<UserService> logger) : base(userRepository, mapper, logger)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserModel> GetUserAsync(string username, CancellationToken ct)
        {
            return mapper.Map<UserModel>(await userRepository.GetUserAsync(username, ct));
        }
    }
}

