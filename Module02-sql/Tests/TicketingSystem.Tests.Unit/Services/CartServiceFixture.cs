using AutoMapper;
using Moq;
using TicketingSystem.Domain.DTOs.CartItem;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Services;

namespace TicketingSystem.Tests.Unit.Services;

public class CartServiceFixture
{
    private readonly CartService _cartService;
    private readonly Mock<ICommonRepository> _repositoryMock;
    private readonly Mock<IMapper> _mapperMock;

    public CartServiceFixture()
    {
        _repositoryMock = new Mock<ICommonRepository>();
        _mapperMock = new Mock<IMapper>();
        _cartService = new CartService(_repositoryMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task GetCartItems_ShouldReturn_CartItems()
    {
        // Arrange
        _repositoryMock.Setup(r => r.CartItems.FindByCartIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new List<CartItem>());
        _mapperMock.Setup(m => m.Map<IEnumerable<CartItemDto>>(It.IsAny<IEnumerable<CartItem>>()))
            .Returns(new List<CartItemDto>());

        // Act
        var result = await _cartService.GetCartItems(1);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task BookItemsAsync_Should_Update_SeatStatus_To_Booked()
    {
        // Arrange
        _repositoryMock.Setup(r => r.Carts.FindByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new Cart());
        _repositoryMock.Setup(r => r.CartItems.FindByCartIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new List<CartItem> { new CartItem { Offer = new Offer { Seat = new Seat() } } });
        _repositoryMock.Setup(r => r.Seats.UpdateAsync(It.IsAny<Seat>())).Returns(Task.FromResult(new Seat()));

        // Act
        await _cartService.BookItemsAsync(1);

        // Assert
        // Check if the UpdateAsync method was called for Seats repository
        _repositoryMock.Verify(r => r.Seats.UpdateAsync(It.IsAny<Seat>()), Times.AtLeastOnce);
    }
}
