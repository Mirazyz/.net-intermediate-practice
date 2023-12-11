using Microsoft.AspNetCore.Mvc;
using Module02_sql.Controllers;
using Moq;
using TicketingSystem.Domain.DTOs.Address;
using TicketingSystem.Domain.DTOs.Event;
using TicketingSystem.Domain.DTOs.Offer;
using TicketingSystem.Domain.DTOs.Payment;
using TicketingSystem.Domain.DTOs.Ticket;
using TicketingSystem.Domain.DTOs.Venue;
using TicketingSystem.Domain.Enums;
using TicketingSystem.Domain.Interfaces.Services;

namespace TicketingSystem.Tests.Unit.Controllers;

public class PaymentsControllerFixture
{
    private readonly Mock<IPaymentService> _paymentServiceMock;
    private readonly PaymentsController _controller;

    public PaymentsControllerFixture()
    {
        _paymentServiceMock = new Mock<IPaymentService>();
        _controller = new PaymentsController(_paymentServiceMock.Object);
    }

    [Fact]
    public async Task GetPaymentByIdAsync_Should_Return_Payment_When_Exists()
    {
        // Arrange
        var address = new AddressDto(1, "Some Details", "Some Landmark", "29.9792", "31.1342", null);
        var venue = new VenueDto(1, "Some Name", address, null);
        var eventDto = new EventDto(1, "Some Event", DateTime.Now, EventStatus.Planned, venue, null);
        var offerList = new List<OfferDto>();
        var ticketDto = new TicketDto(1, TicketStatus.Booked, eventDto, null, null, offerList);
        var paymentDto = new PaymentDto(1, "Some Payment Details", "1234-5678-9012-3456", 50.0m, ticketDto);

        _paymentServiceMock.Setup(ps => ps.GetPaymentById(It.IsAny<int>()))
            .ReturnsAsync(paymentDto);

        // Act
        var result = await _controller.GetPaymentByIdAsync(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(paymentDto, okResult.Value);
    }

    [Fact]
    public async Task CompletePaymentAsync_Should_Return_NoContent()
    {
        // Arrange
        _paymentServiceMock.Setup(ps => ps.CompletePayment(It.IsAny<int>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.CompletePaymentAsync(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task CancellPaymentAsync_Should_Return_NoContent()
    {
        // Arrange
        _paymentServiceMock.Setup(ps => ps.CancellPayment(It.IsAny<int>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.CancellPaymentAsync(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
