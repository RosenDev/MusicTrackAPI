using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IUserRepository userRepository;

        public AuthenticationService(
			IConfiguration configuration,
			IUserRepository userRepository,
			IMapper mapper
			)
		{
            this.configuration = configuration;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<Tokens> AuthenticateAsync(UserLoginModel userLoginModel, CancellationToken ct = default)
        {
			var userEntity = await userRepository.GetUserAsync(userLoginModel.Username, ct);

			if(userEntity == null)
            {
				throw new ArgumentNullException(userLoginModel.Username, "The user is not yet registered!");
            }

			if(!PBKDF2HashGenerator.VerifyHash(userLoginModel.Password, userEntity.Password, userEntity.Salt))
            {
				throw new ArgumentNullException(userLoginModel.Username, "Incorrect password!");
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

		public async Task<Tokens> RegisterUserAsync(UserRegisterModel user, CancellationToken ct = default)
		{
			var userEntity = mapper.Map<User>(user);

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

