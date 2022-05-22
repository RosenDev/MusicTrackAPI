using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MusicTrackAPI.Data;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories;
using MusicTrackAPI.Services.Model;

namespace MusicTrackAPI.Services
{
	public class AuthenticationService: IAuthenticationService
	{
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public AuthenticationService(
			IConfiguration configuration,
			MusicTrackAPIDbContext context,
			IMapper mapper
			)
		{
            this.configuration = configuration;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<Tokens> AuthenticateAsync(UserModel user, CancellationToken ct = default)
        {
			var hashedPassword = PBKDF2HashGenerator.CreateHash(user.Password);

			var userEntity = await userRepository.GetUserAsync(user.Username, ct);

			if(userEntity == null)
            {
				throw new ArgumentNullException(user.Username, "The user is not yet registered!");
            }

			if(userEntity.Password != hashedPassword)
            {
				throw new ArgumentNullException(user.Username, "Incorrect password!");
			}

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

		public async Task<Tokens> RegisterUserAsync(UserModel user, CancellationToken ct = default)
		{
			user.Password = PBKDF2HashGenerator.CreateHash(user.Password);

			var userEntity = mapper.Map<User>(user);


			await userRepository.AddAsync(userEntity, ct);

			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
			  {
			 new Claim(ClaimTypes.Name, userEntity.Username)
			  }),
				Expires = DateTime.UtcNow.AddMinutes(10),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return new Tokens { Token = tokenHandler.WriteToken(token) };
		}
	}
}

