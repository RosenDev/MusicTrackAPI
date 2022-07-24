using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using MusicTrackAPI.Common;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;
using Xunit;

namespace MusicTrackAPI.Tests;

public class TracksServiceTests
{
    [Fact]
    public async Task TrackService_QueryAsync_WhenThereIsData_ShouldReturnTracks()
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
    public async Task TrackService_QueryAsync_WhenThereIsNoData_ShouldReturnNoTracks()
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
    public async Task TrackService_GetByIdAsync_ShouldReturnTrack_WhenThereIsSuch()
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

        trackServiceMock.Setup(x => x.GetByIdAsync(It.Is<int>(x => x == 7), default))
            .ReturnsAsync(() => testTrack);

        var trackService = trackServiceMock.Object;

        Assert.NotNull(await trackService.GetByIdAsync(7, default));
    }

    [Fact]
    public async Task TrackService_GetByIdAsync_ShouldReturnNull_WhenThereIsNotTtack()
    {
        var trackServiceMock = new Mock<ITrackService>();
 
        trackServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), default))
            .ReturnsAsync(() => null);

        var trackService = trackServiceMock.Object;

        Assert.Null(await trackService.GetByIdAsync(7, default));
    }
}
