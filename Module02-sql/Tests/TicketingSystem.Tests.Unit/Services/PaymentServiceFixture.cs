using AutoMapper;
using Moq;
using TicketingSystem.Domain.DTOs.Payment;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Enums;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Services;

namespace TicketingSystem.Tests.Unit.Services;

public class PaymentServiceFixture
{
    private readonly Mock<ICommonRepository> _repositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly PaymentService _paymentService;

    public PaymentServiceFixture()
    {
        _repositoryMock = new Mock<ICommonRepository>();
        _mapperMock = new Mock<IMapper>();
        _paymentService = new PaymentService(_repositoryMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task GetPaymentById_Should_Return_PaymentDto()
    {
        // Arrange
        var payment = new Payment();
        _repositoryMock.Setup(r => r.Payments.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(payment);
        _mapperMock.Setup(m => m.Map<PaymentDto>(It.IsAny<Payment>())).Returns(new PaymentDto(1, "PaymentDetails", "123124", 500, null));

        // Act
        var result = await _paymentService.GetPaymentById(1);

        // Assert
        Assert.IsType<PaymentDto>(result);
    }

    [Fact]
    public async Task CompletePayment_Should_Change_Payment_And_Ticket_Statuses_And_Save_Changes()
    {
        // Arrange
        var payment = new Payment { Status = PaymentStatus.Completed, TicketId = 1 };
        var ticket = new Ticket { Status = TicketStatus.Booked };

        _repositoryMock.Setup(r => r.Payments.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(payment);
        _repositoryMock.Setup(r => r.Tickets.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(ticket);
        _repositoryMock.Setup(r => r.Seats.FindByTicketId(It.IsAny<int>())).ReturnsAsync(new List<Seat>());

        // Act
        await _paymentService.CompletePayment(1);

        // Assert
        Assert.Equal(PaymentStatus.Completed, payment.Status);
        Assert.Equal(TicketStatus.Sold, ticket.Status);
        _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Exactly(1));
    }
}
