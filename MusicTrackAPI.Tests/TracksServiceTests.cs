using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using MusicTrackAPI.Common;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Track;
using MusicTrackAPI.Services.Interface;
using Xunit;

namespace MusicTrackAPI.Tests;

public class TracksServiceTests
{
    [Fact]
    public async Task TrackService_QueryAsync_ShouldReturnTracks_WhenThereIsData()
    {
        var trackServiceMock = new Mock<ITrackService>();
        var testTrack = new TrackModel
        {
            Name = "Test track",
            ArrangedBy = "Test User",
            PerformedBy = "Another Test User",
            WrittenBy = "Test",
            Type = TrackType.FilmMusic,
            Duration = TimeSpan.Zero
        };
        var testData = new List<TrackModel> { testTrack };
        trackServiceMock.Setup(x => x.QueryAsync(It.IsAny<List<FieldFilter>>(), It.IsAny<Paging>(), default))
            .ReturnsAsync(() => new PagedResponse<TrackModel> { Result = testData });

        var trackService = trackServiceMock.Object;

        Assert.Equal(testData.Count, (await trackService.QueryAsync(new List<FieldFilter>(), new Paging(), default)).Result.Count);
    }

    [Fact]
    public async Task TrackService_QueryAsync_ShouldReturnNoTracks_WhenThereIsNoData()
    {
        var trackServiceMock = new Mock<ITrackService>();
        var testTrack = new TrackModel
        {
            Name = "Test track",
            ArrangedBy = "Test User",
            PerformedBy = "Another Test User",
            WrittenBy = "Test",
            Type = TrackType.FilmMusic,
            Duration = TimeSpan.Zero
        };
        var testData = new List<TrackModel> { testTrack };
        trackServiceMock.Setup(x => x.QueryAsync(It.IsAny<List<FieldFilter>>(), It.IsAny<Paging>(), default))
            .ReturnsAsync(() => new PagedResponse<TrackModel> { Result = testData });

        var trackService = trackServiceMock.Object;

        Assert.Empty((await trackService.QueryAsync(new List<FieldFilter>(), new Paging(), default)).Result);
    }


    [Fact]
    public async Task TrackService_GetByIdAsync_ShouldNotReturnNull_WhenTrackExists()
    {
        var trackServiceMock = new Mock<ITrackService>();
        var testTrack = new TrackModel
        {
            Id = 7,
            Name = "Test track",
            ArrangedBy = "Test User",
            PerformedBy = "Another Test User",
            WrittenBy = "Test",
            Type = TrackType.LivePerformance,
            Duration = TimeSpan.Zero
        };

        trackServiceMock.Setup(x => x.GetByIdAsync(It.Is<int>(x => x == testTrack.Id), default))
            .ReturnsAsync(() => testTrack);

        var trackService = trackServiceMock.Object;

        Assert.NotNull(await trackService.GetByIdAsync(testTrack.Id, default));
    }

    [Fact]
    public async Task TrackService_GetByIdAsync_ShouldReturnNull_WhenTrackDoesNotExists()
    {
        var trackServiceMock = new Mock<ITrackService>();
 
        trackServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), default))
            .ReturnsAsync(() => null);

        var trackService = trackServiceMock.Object;

        Assert.Null(await trackService.GetByIdAsync(7, default));
    }

    [Fact]
    public async Task TrackService_UpdateTrackAsync_ShouldReturnTrackId_WhenTrackExists()
    {
        var trackServiceMock = new Mock<ITrackService>();
        var testTrack = new TrackModel
        {
            Id = 7,
            Name = "Test track",
            ArrangedBy = "Test User",
            PerformedBy = "Another Test User",
            WrittenBy = "Test",
            Type = TrackType.LivePerformance,
            Duration = TimeSpan.Zero
        };

        trackServiceMock.Setup(x => x.UpdateTrackAsync(It.Is<int>(x => x == testTrack.Id), default))
            .ReturnsAsync(() => testTrack);

        var trackService = trackServiceMock.Object;

        Assert.NotNull(await trackService.GetByIdAsync(7, default));
    }

    [Fact]
    public async Task TrackService_UpdateTrackAsync_ShouldThrowException_WhenTrackDoesNotExists()
    {
        var trackServiceMock = new Mock<ITrackService>();

        trackServiceMock.Setup(x => x.UpdateTrackAsync(It.IsAny<TrackUpdateModel>(), default))
            .ThrowsAsync(new ArgumentException("Track does not exist"));

        var trackService = trackServiceMock.Object;

        await Assert.ThrowsAsync<ArgumentException>(() => trackService.UpdateTrackAsync(new TrackUpdateModel(), default));
    }

    [Fact]
    public async Task TrackService_DeleteAsync_ShouldReturnTrue_WhenTrackExists()
    {
        var trackServiceMock = new Mock<ITrackService>();
        var testTrack = new TrackModel
        {
            Id = 7,
            Name = "Test track",
            ArrangedBy = "Test User",
            PerformedBy = "Another Test User",
            WrittenBy = "Test",
            Type = TrackType.LivePerformance,
            Duration = TimeSpan.Zero
        };

        trackServiceMock.Setup(x => x.DeleteAsync(It.Is<int>(x => x == testTrack.Id), default))
            .ReturnsAsync(() => true);

        var trackService = trackServiceMock.Object;

        Assert.True(await trackService.DeleteAsync(testTrack.Id, default));
    }

    [Fact]
    public async Task TrackService_DeleteAsync_ShouldReturnFalse_WhenTrackDoesNotExists()
    {
        var trackServiceMock = new Mock<ITrackService>();

        trackServiceMock.Setup(x => x.DeleteAsync(It.IsAny<int>(), default))
            .ReturnsAsync(() => false);

        var trackService = trackServiceMock.Object;

        Assert.False(await trackService.DeleteAsync(7, default));
    }
}
