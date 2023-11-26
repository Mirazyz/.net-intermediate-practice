using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Domain.DTOs.Payment;
using TicketingSystem.Domain.Interfaces.Services;

namespace Module02_sql.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetPaymentByIdAsync(int id)
        {
            var payment = await _paymentService.GetPaymentById(id);

            return Ok(payment);
        }

        [HttpGet("{id}/complete")]
        public async Task<ActionResult> CompletePaymentAsync(int id)
        {
            await _paymentService.CompletePayment(id);

            return NoContent();
        }

        [HttpGet("{id}/failed")]
        public async Task<ActionResult> CancellPaymentAsync(int id)
        {
            await _paymentService.CancellPayment(id);

            return NoContent();
        }
    }
}
