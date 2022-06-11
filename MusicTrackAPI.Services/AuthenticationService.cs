﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories;
using MusicTrackAPI.Model;

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
			var hashedPassword = PBKDF2HashGenerator.CreateHash(userLoginModel.Password);

			var userEntity = await userRepository.GetUserAsync(userLoginModel.Username, ct);

			if(userEntity == null)
            {
				throw new ArgumentNullException(userLoginModel.Username, "The user is not yet registered!");
            }

			if(userEntity.Password != hashedPassword)
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

