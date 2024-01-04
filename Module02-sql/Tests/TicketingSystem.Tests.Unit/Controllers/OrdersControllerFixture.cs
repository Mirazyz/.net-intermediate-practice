using Microsoft.AspNetCore.Mvc;
using Module02_sql.Controllers;
using Moq;
using TicketingSystem.Domain.DTOs.Cart;
using TicketingSystem.Domain.DTOs.CartItem;
using TicketingSystem.Domain.DTOs.Customer;
using TicketingSystem.Domain.DTOs.Ticket;
using TicketingSystem.Domain.Interfaces.Services;

namespace TicketingSystem.Tests.Unit.Controllers;

public class OrdersControllerFixture
{
    private readonly Mock<ICartService> _cartServiceMock;
    private readonly OrdersController _controller;

    public OrdersControllerFixture()
    {
        _cartServiceMock = new Mock<ICartService>();
        _controller = new OrdersController(_cartServiceMock.Object);
    }

    [Fact]
    public async Task GetCartByIdAsync_Should_Return_Ok_With_CartItems()
    {
        // Arrange
        _cartServiceMock.Setup(cs => cs.GetCartItemsAsync(It.IsAny<int>()))
            .ReturnsAsync(new List<CartItemDto>());

        // Act
        var result = await _controller.GetCartByIdAsync(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.IsAssignableFrom<IEnumerable<CartItemDto>>(okResult.Value);
    }

    [Fact]
    public async Task AddCartItemAsync_Should_Return_BadRequest_When_CartIds_DoNotMatch()
    {
        // Arrange
        var itemToCreate = new CartItemForCreateDto(2, 1);

        // Act
        var result = await _controller.AddCartItemAsync(1, itemToCreate);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }

    [Fact]
    public async Task AddCartItemAsync_Should_Return_Cart_When_Successful()
    {
        // Arrange
        var customer = new CustomerDto(1, "John", "Doe", "1234567890", new DateTime(2000, 1, 1), new List<TicketDto>());

        var itemToCreate = new CartItemForCreateDto(1, 1);
        _cartServiceMock.Setup(cs => cs.AddCartItemAsync(itemToCreate))
            .ReturnsAsync(new CartDto(1, 200, customer, new List<CartItemDto>()));

        // Act
        var result = await _controller.AddCartItemAsync(1, itemToCreate);

        // Assert
        var okResult = Assert.IsType<CartDto>(result.Value);
    }

    [Fact]
    public async Task DeleteSeatForEventAsync_Should_Return_NoContent()
    {
        // Arrange
        _cartServiceMock.Setup(cs => cs.DeleteItemAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.DeleteSeatForEventAsync(1, 2, 3);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task BookCartItemsAsync_Should_Return_NoContent()
    {
        // Arrange
        _cartServiceMock.Setup(cs => cs.BookItemsAsync(It.IsAny<int>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.BookCartItemsAsync(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
