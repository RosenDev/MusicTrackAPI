using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using MusicTrackAPI.Common;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Playlist;
using MusicTrackAPI.Services.Interface;
using Xunit;

namespace MusicTrackAPI.Tests;

public class PlaylistServiceTests
{
    [Fact]
    public async Task PlaylistService_QueryAsync_ShouldReturnPlaylists_WhenThereIsData()
    {
        var playlistServiceMock = new Mock<IPlaylistService>();
        var testPlaylist = new PlaylistModel
        {
            Name = "Test Playlist",
            IsPublic = true,
            Duration = TimeSpan.Zero
        };
        var testData = new List<PlaylistModel> { testPlaylist };
        playlistServiceMock.Setup(x => x.QueryAsync(It.IsAny<List<FieldFilter>>(), It.IsAny<Paging>(), default))
            .ReturnsAsync(() => new PagedResponse<PlaylistModel> { Result = testData });

        var playlistService = playlistServiceMock.Object;

        Assert.Equal(testData.Count, (await playlistService.QueryAsync(new List<FieldFilter>(), new Paging(), default)).Result.Count);
    }

    [Fact]
    public async Task PlaylistService_QueryAsync_ShouldNotReturnPlaylists_WhenThereIsNoData()
    {
        var playlistServiceMock = new Mock<IPlaylistService>();

        var testData = new List<PlaylistModel>();
        playlistServiceMock.Setup(x => x.QueryAsync(It.IsAny<List<FieldFilter>>(), It.IsAny<Paging>(), default))
           .ReturnsAsync(() => new PagedResponse<PlaylistModel> { Result = testData });

        var playlistService = playlistServiceMock.Object;

        Assert.Empty((await playlistService.QueryAsync(new List<FieldFilter>(), new Paging(), default)).Result);
    }


    [Fact]
    public async Task PlaylistService_GetByIdAsync_ShouldNotReturnNull_WhenPlaylistExists()
    {
        var playlistServiceMock = new Mock<IPlaylistService>();
        var testPlaylist = new PlaylistModel
        {
            Name = "Test Playlist",
            IsPublic = true,
            Duration = TimeSpan.Zero
        };
        playlistServiceMock.Setup(x => x.GetByIdAsync(It.Is<int>(x => x == testPlaylist.Id), default))
            .ReturnsAsync(() => testPlaylist);

        var playlistService = playlistServiceMock.Object;

        Assert.NotNull(await playlistService.GetByIdAsync(testPlaylist.Id, default));
    }

    [Fact]
    public async Task PlaylistService_GetByIdAsync_ShouldReturnNull_WhenPlaylistDoesNotExists()
    {
        var playlistServiceMock = new Mock<IPlaylistService>();

        playlistServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), default))
            .ReturnsAsync(() => null);

        var playlistService = playlistServiceMock.Object;

        Assert.Null(await playlistService.GetByIdAsync(7, default));
    }

    [Fact]
    public async Task PlaylistService_UpdatePlaylistAsync_ShouldReturnPlaylistId_WhenPlaylistExists()
    {
        var playlistServiceMock = new Mock<IPlaylistService>();
        var testPlaylist = new PlaylistModel
        {
            Name = "Test Playlist",
            IsPublic = true,
            Duration = TimeSpan.Zero
        };

        playlistServiceMock.Setup(x => x.UpdatePlaylistAsync(It.Is<PlaylistUpdateModel>(x => x.Id == testPlaylist.Id), default))
            .ReturnsAsync(() => testPlaylist.Id);

        var playlistService = playlistServiceMock.Object;

        Assert.Equal(testPlaylist.Id, await playlistService.UpdatePlaylistAsync(new PlaylistUpdateModel { Id = 7, IsPublic = true }, default));
    }

    [Fact]
    public async Task PlaylistService_UpdatePlaylistAsync_ShouldThrowException_WhenPlaylistDoesNotExists()
    {
        var playlistServiceMock = new Mock<IPlaylistService>();

        playlistServiceMock.Setup(x => x.UpdatePlaylistAsync(It.IsAny<PlaylistUpdateModel>(), default))
            .ThrowsAsync(new ArgumentException("Playlist does not exist"));

        var playlistService = playlistServiceMock.Object;

        await Assert.ThrowsAsync<ArgumentException>(() => playlistService.UpdatePlaylistAsync(new PlaylistUpdateModel(), default));
    }

    [Fact]
    public async Task PlaylistService_DeleteAsync_ShouldReturnTrue_WhenPlaylistExists()
    {
        var playlistServiceMock = new Mock<IPlaylistService>();
        var testPlaylist = new PlaylistModel
        {
            Name = "Test Playlist",
            IsPublic = true,
            Duration = TimeSpan.Zero
        };

        playlistServiceMock.Setup(x => x.DeleteAsync(It.Is<int>(x => x == testPlaylist.Id), default))
            .ReturnsAsync(() => true);

        var playlistService = playlistServiceMock.Object;

        Assert.True(await playlistService.DeleteAsync(testPlaylist.Id, default));
    }

    [Fact]
    public async Task PlaylistService_DeleteAsync_ShouldReturnFalse_WhenPlaylistDoesNotExists()
    {
        var playlistServiceMock = new Mock<IPlaylistService>();

        playlistServiceMock.Setup(x => x.DeleteAsync(It.IsAny<int>(), default))
            .ReturnsAsync(() => false);

        var playlistService = playlistServiceMock.Object;

        Assert.False(await playlistService.DeleteAsync(7, default));
    }
}
