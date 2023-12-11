using Microsoft.AspNetCore.Mvc;
using Module02_sql.Controllers;
using Moq;
using TicketingSystem.Domain.DTOs.Section;
using TicketingSystem.Domain.DTOs.Venue;
using TicketingSystem.Domain.Interfaces.Services;

namespace TicketingSystem.Tests.Unit.Controllers;

public class VenuesControllerFixture
{
    private readonly VenuesController _controller;
    private readonly Mock<IVenueService> _venueServiceMock;

    public VenuesControllerFixture()
    {
        _venueServiceMock = new Mock<IVenueService>();
        _controller = new VenuesController(_venueServiceMock.Object);
    }

    [Fact]
    public async Task GetVenuesAsync_Should_Return_Ok_With_Venues()
    {
        // Arrange
        _venueServiceMock.Setup(vs => vs.GetVenuesAsync())
            .ReturnsAsync(new List<VenueDto>());

        // Act
        var result = await _controller.GetVenuesAsync();

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.IsAssignableFrom<IEnumerable<VenueDto>>(actionResult.Value);
    }

    [Fact]
    public async Task GetSectionsAsync_Should_Return_Ok_With_Sections()
    {
        // Arrange
        _venueServiceMock.Setup(vs => vs.GetSectionsByVenueIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new List<SectionDto>());

        // Act
        var result = await _controller.GetSectionsAsync(It.IsAny<int>());

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.IsAssignableFrom<IEnumerable<SectionDto>>(actionResult.Value);
    }
}
