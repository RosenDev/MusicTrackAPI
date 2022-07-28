using System;
using System.Threading.Tasks;
using Moq;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;
using Xunit;

namespace MusicTrackAPI.Tests
{ 
	public class UserServiceTests
	{
        [Fact]
		public async Task GetUser_ShouldReturnUser()
        {
			var userServiceMock = new Mock<IUserService>();
			var testData = new UserModel
			{
				Username = "Test User",
				Email = "test@user.com",
			};
			userServiceMock.Setup(x => x.GetUserAsync(testData.Username, default))
				.ReturnsAsync(() => testData);

			var userService = userServiceMock.Object;

		    Assert.Equal(testData.Email, (await userService.GetUserAsync(testData.Username, default)).Email);
        }
	}
}

