using AutoMapper;
using TicketingSystem.Domain.DTOs.Payment;
using TicketingSystem.Domain.Exceptions;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Domain.Interfaces.Services;

namespace TicketingSystem.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ICommonRepository _repository;
        private readonly IMapper _mapper;

        public PaymentService(ICommonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaymentDto> GetPaymentById(int id)
        {
            var payment = await _repository.Payments.FindByIdAsync(id);

            var paymentDto = _mapper.Map<PaymentDto>(payment);

            return paymentDto;
        }

        public async Task CompletePayment(int id)
        {
            var payment = await _repository.Payments.FindByIdAsync(id);

            if (payment is null)
            {
                throw new EntityNotFoundException($"Payment with id: {id} does not exist.");
            }

            payment.Status = Domain.Enums.PaymentStatus.Completed;

            var ticket = await _repository.Tickets.FindByIdAsync(payment.TicketId);
            ticket.Status = Domain.Enums.TicketStatus.Sold;

            var seats = await _repository.Seats.FindByTicketId(id);

            foreach (var seat in seats)
            {
                seat.Status = Domain.Enums.SeatStatus.Sold;
            }

            await _repository.SaveChangesAsync();
        }

        public async Task CancellPayment(int id)
        {
            var payment = await _repository.Payments.FindByIdAsync(id);

            if (payment is null)
            {
                throw new EntityNotFoundException($"Payment with id: {id} does not exist.");
            }

            payment.Status = Domain.Enums.PaymentStatus.Cancelled;

            var ticket = await _repository.Tickets.FindByIdAsync(payment.TicketId);
            ticket.Status = Domain.Enums.TicketStatus.Available;

            var seats = await _repository.Seats.FindByTicketId(id);

            foreach (var seat in seats)
            {
                seat.Status = Domain.Enums.SeatStatus.Available;
            }

            await _repository.SaveChangesAsync();
        }
    }
}
