using AutoMapper;
using Moq;
using TicketingSystem.Domain.DTOs.Section;
using TicketingSystem.Domain.DTOs.Venue;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Services;

namespace TicketingSystem.Tests.Unit.Services;

public class VenuesServiceFixture
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ICommonRepository> _repositoryMock;
    private readonly VenueService _venueService;

    public VenuesServiceFixture()
    {
        _mapperMock = new Mock<IMapper>();
        _repositoryMock = new Mock<ICommonRepository>();
        _venueService = new VenueService(_mapperMock.Object, _repositoryMock.Object);
    }

    [Fact]
    public async Task GetSectionsByVenueIdAsync_ShouldReturnSections_WhenSectionsExist()
    {
        // Arrange
        _repositoryMock.Setup(r => r.Sections.FindByVenueIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new List<Section>());
        _mapperMock.Setup(m => m.Map<IEnumerable<SectionDto>>(It.IsAny<IEnumerable<Section>>()))
            .Returns(new List<SectionDto>());

        // Act
        var result = await _venueService.GetSectionsByVenueIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, item => Assert.IsType<SectionDto>(item));
    }

    [Fact]
    public async Task GetSectionsByVenueIdAsync_ShouldReturnEmpty_WhenNoSectionsExist()
    {
        // Arrange
        _repositoryMock.Setup(r => r.Sections.FindByVenueIdAsync(It.IsAny<int>())).ReturnsAsync((List<Section>)null);
        _mapperMock.Setup(m => m.Map<IEnumerable<SectionDto>>(null)).Returns(Enumerable.Empty<SectionDto>());

        // Act
        var result = await _venueService.GetSectionsByVenueIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetVenuesAsync_ShouldReturnVenues_WhenVenuesExist()
    {
        // Arrange
        _repositoryMock.Setup(r => r.Venues.FindAllAsync()).ReturnsAsync(new List<Venue>());
        _mapperMock.Setup(m => m.Map<IEnumerable<VenueDto>>(It.IsAny<IEnumerable<Venue>>()))
            .Returns(new List<VenueDto>());

        // Act
        var result = await _venueService.GetVenuesAsync();

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetVenuesAsync_ShouldReturnEmpty_WhenNoVenuesExist()
    {
        // Arrange
        _repositoryMock.Setup(r => r.Venues.FindAllAsync()).ReturnsAsync((List<Venue>)null);
        _mapperMock.Setup(m => m.Map<IEnumerable<VenueDto>>(null)).Returns(Enumerable.Empty<VenueDto>());

        // Act
        var result = await _venueService.GetVenuesAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }
}
