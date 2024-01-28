using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Domain.DTOs;
using TicketingSystem.Domain.DTOs.Payment;
using TicketingSystem.Domain.Interfaces.Services;

namespace Module02_sql.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMessageProducer _messageProducer;

        public PaymentsController(IPaymentService paymentService, IMessageProducer messageProducer)
        {
            _paymentService = paymentService;
            _messageProducer = messageProducer;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetPaymentByIdAsync(int id)
        {
            var payment = await _paymentService.GetPaymentById(id);

            return Ok(payment);
        }

        [HttpPut("{id}/complete")]
        public async Task<ActionResult> CompletePaymentAsync(int id)
        {
            try
            {
                await _paymentService.CompletePayment(id);
                _messageProducer.SendMessage(new NotificationDto(
                    Guid.NewGuid(),
                    OperationType.PaymentSucceeded,
                    DateTime.Now,
                    new NotificationParameters("John Doe", "john@gmail.com"),
                    $"Payment: {id} completed successfully."));

                return NoContent();
            }
            catch
            {
                _messageProducer.SendMessage(new NotificationDto(
                    Guid.NewGuid(),
                    OperationType.PaymentFailed,
                    DateTime.Now,
                    new NotificationParameters("John Doe", "john@gmail.com"),
                    $"Payment: {id} failed."));
                throw;
            }
        }

        [HttpPost("{id}/failed")]
        public async Task<ActionResult> CancellPaymentAsync(int id)
        {
            await _paymentService.CancellPayment(id);

            return NoContent();
        }
    }
}
