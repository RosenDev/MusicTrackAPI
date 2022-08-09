using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using MusicTrackAPI.Common;
using MusicTrackAPI.Model.Album;
using MusicTrackAPI.Services.Interface;
using Xunit;

namespace MusicTrackAPI.Tests;

public class AlbumServiceTests
{
    [Fact]
    public async Task AlbumService_QueryAsync_ShouldReturnAlbums_WhenThereIsData()
    {
        var albumServiceMock = new Mock<IAlbumService>();
        var testAlbum = new AlbumModel
        {
            Name = "Test album",
            PublishingYear = 2022,
            Duration = TimeSpan.Zero
        };
        var testData = new List<AlbumModel> { testAlbum };
        albumServiceMock.Setup(x => x.QueryAsync(It.IsAny<List<FieldFilter>>(), It.IsAny<Paging>(), default))
            .ReturnsAsync(() => new PagedResponse<AlbumModel> { Result = testData });

        var albumService = albumServiceMock.Object;

        Assert.Equal(testData.Count, (await albumService.QueryAsync(new List<FieldFilter>(), new Paging(), default)).Result.Count);
    }

    [Fact]
    public async Task AlbumService_QueryAsync_ShouldNotReturnAlbums_WhenThereIsNoData()
    {
        var albumServiceMock = new Mock<IAlbumService>();
     
        var testData = new List<AlbumModel>();
         albumServiceMock.Setup(x => x.QueryAsync(It.IsAny<List<FieldFilter>>(), It.IsAny<Paging>(), default))
            .ReturnsAsync(() => new PagedResponse<AlbumModel> { Result = testData });

        var albumService = albumServiceMock.Object;

        Assert.Empty((await albumService.QueryAsync(new List<FieldFilter>(), new Paging(), default)).Result);
    }


    [Fact]
    public async Task AlbumService_GetByIdAsync_ShouldNotReturnNull_WhenAlbumExists()
    {
        var albumServiceMock = new Mock<IAlbumService>();
        var testAlbum = new AlbumModel
        {
            Name = "Test album",
            PublishingYear = 2022,
            Duration = TimeSpan.Zero
        };
        albumServiceMock.Setup(x => x.GetByIdAsync(It.Is<int>(x => x == testAlbum.Id), default))
            .ReturnsAsync(() => testAlbum);

        var albumService = albumServiceMock.Object;

        Assert.NotNull(await albumService.GetByIdAsync(testAlbum.Id, default));
    }

    [Fact]
    public async Task AlbumService_GetByIdAsync_ShouldReturnNull_WhenAlbumDoesNotExists()
    {
        var albumServiceMock = new Mock<IAlbumService>();

        albumServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), default))
            .ReturnsAsync(() => null);

        var albumService = albumServiceMock.Object;

        Assert.Null(await albumService.GetByIdAsync(7, default));
    }

    [Fact]
    public async Task AlbumService_UpdateAlbumAsync_ShouldReturnAlbumId_WhenAlbumExists()
    {
        var albumServiceMock = new Mock<IAlbumService>();
        var testAlbum = new AlbumModel
        {
            Name = "Test album",
            PublishingYear = 2022,
            Duration = TimeSpan.Zero
        };

        albumServiceMock.Setup(x => x.UpdateAlbumAsync(It.Is<AlbumUpdateModel>(x => x.Id == testAlbum.Id), default))
            .ReturnsAsync(() => testAlbum.Id);

        var albumService = albumServiceMock.Object;

        Assert.Equal(testAlbum.Id, await albumService.UpdateAlbumAsync(new AlbumUpdateModel { Id = 7, PublishingYear = 2022 }, default));
    }

    [Fact]
    public async Task AlbumService_UpdateAlbumAsync_ShouldThrowException_WhenAlbumDoesNotExists()
    {
        var albumServiceMock = new Mock<IAlbumService>();

        albumServiceMock.Setup(x => x.UpdateAlbumAsync(It.IsAny<AlbumUpdateModel>(), default))
            .ThrowsAsync(new ArgumentException("Album does not exist"));

        var albumService = albumServiceMock.Object;

        await Assert.ThrowsAsync<ArgumentException>(() => albumService.UpdateAlbumAsync(new AlbumUpdateModel(), default));
    }

    [Fact]
    public async Task AlbumService_DeleteAsync_ShouldReturnTrue_WhenAlbumExists()
    {
        var albumServiceMock = new Mock<IAlbumService>();
        var testAlbum = new AlbumModel
        {
            Name = "Test album",
            PublishingYear = 2022,
            Duration = TimeSpan.Zero
        };

        albumServiceMock.Setup(x => x.DeleteAsync(It.Is<int>(x => x == testAlbum.Id), default))
            .ReturnsAsync(() => true);

        var albumService = albumServiceMock.Object;

        Assert.True(await albumService.DeleteAsync(testAlbum.Id, default));
    }

    [Fact]
    public async Task AlbumService_DeleteAsync_ShouldReturnFalse_WhenAlbumDoesNotExists()
    {
        var albumServiceMock = new Mock<IAlbumService>();

        albumServiceMock.Setup(x => x.DeleteAsync(It.IsAny<int>(), default))
            .ReturnsAsync(() => false);

        var albumService = albumServiceMock.Object;

        Assert.False(await albumService.DeleteAsync(7, default));
    }
}
