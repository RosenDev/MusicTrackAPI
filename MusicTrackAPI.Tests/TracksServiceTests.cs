using Moq;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;
using Xunit;

namespace MusicTrackAPI.Tests;

public class TracksServiceTests
{
    [Fact]
    public void TrackService_QueryAsync_WhenThereIsData_ShouldReturnTracks()
    {
        var trackServiceMock = new Mock<ITrackService>();
        var testData = new UserModel
        {
            Username = "Test User",
            Email = "test@user.com",
        };
        trackServiceMock.Setup(x => x.)
            .ReturnsAsync(() => testData);

        var trackService = trackServiceMock.Object;

        Assert.Equal(testData.Email, (await trackService.GetUserAsync(testData.Username, default)).Email);
    }

    [Fact]
    public void TrackService_QueryAsync_WhenThereIsNoData_ShouldReturnNoTracks()
    {

    }
}
