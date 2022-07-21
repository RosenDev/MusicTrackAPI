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
    public void TrackService_QueryAsync_WhenThereIsData_ShouldReturnTracks()
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

        Assert.Equal(testData[0].Name, (await trackService.QueryAsync(new List<FieldFilter>(), new Paging(), default)).Result[0].Name);
    }

    [Fact]
    public void TrackService_QueryAsync_WhenThereIsNoData_ShouldReturnNoTracks()
    {

    }
}
