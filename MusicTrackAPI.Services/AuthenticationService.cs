using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MusicTrackAPI.Common;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories;
using MusicTrackAPI.Data.Repositories.Interfaces;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Services
{
    public class AuthenticationService: IAuthenticationService
	{
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly ILogger<AuthenticationService> logger;
        private readonly IUserRepository userRepository;

        public AuthenticationService(
			IConfiguration configuration,
			IUserRepository userRepository,
			IMapper mapper,
			ILogger<AuthenticationService> logger
			)
		{
            this.configuration = configuration;
            this.mapper = mapper;
            this.logger = logger;
            this.userRepository = userRepository;
        }

        public async Task<Tokens> AuthenticateAsync(UserLoginModel userLoginModel, CancellationToken ct)
        {
			var userEntity = await userRepository.GetUserAsync(userLoginModel.Username, ct);

			if(userEntity == null)
            {
				logger.LogWarning(ErrorMessages.UserDoesNotExist);

				throw new ArgumentException(ErrorMessages.UserDoesNotExist);
            }

			if(!PBKDF2HashGenerator.VerifyHash(userLoginModel.Password, userEntity.Password, userEntity.Salt))
            {
				logger.LogWarning(ErrorMessages.InvalidPassword);

				throw new ArgumentException(ErrorMessages.InvalidPassword);
			}

			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
			  {
			 new Claim(ClaimTypes.Name, userLoginModel.Username)
			  }),
				Expires = DateTime.UtcNow.AddMinutes(10),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return new Tokens { Token = tokenHandler.WriteToken(token) };
		}

		public async Task<Tokens> RegisterUserAsync(UserRegisterModel user, CancellationToken ct)
		{
			var userEntity = mapper.Map<User>(user);

			var exisitngUser = await userRepository.GetUserAsync(userEntity.Username, ct);

			if(exisitngUser != null)
            {
				logger.LogWarning(ErrorMessages.UserAlreadyExist);

				throw new ArgumentException(ErrorMessages.UserAlreadyExist);
            }

			var hashResult = PBKDF2HashGenerator.CreateHash(userEntity.Password);
			
			userEntity.Password = hashResult.Hash;
			userEntity.Salt = hashResult.Salt;

			await userRepository.AddAsync(userEntity, ct);

			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
			  {
			 new Claim(ClaimTypes.Name, user.Username)
			  }),
				Expires = DateTime.UtcNow.AddMinutes(10),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return new Tokens { Token = tokenHandler.WriteToken(token) };
		}
	}
}

