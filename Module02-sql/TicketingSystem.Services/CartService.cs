using AutoMapper;
using TicketingSystem.Domain.DTOs.Cart;
using TicketingSystem.Domain.DTOs.CartItem;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Exceptions;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Domain.Interfaces.Services;

namespace TicketingSystem.Services
{
    public class CartService : ICartService
    {
        private readonly ICommonRepository _repository;
        private readonly IMapper _mapper;

        public CartService(ICommonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CartItemDto>> GetCartItems(int cartId)
        {
            var cartItemEntities = await _repository.CartItems.FindByCartIdAsync(cartId);

            var cartItemDtos = _mapper.Map<IEnumerable<CartItemDto>>(cartItemEntities);

            return cartItemDtos ?? Enumerable.Empty<CartItemDto>();
        }

        public async Task BookItemsAsync(int id)
        {
            var cart = _repository.Carts.FindByIdAsync(id);

            if (cart is null)
            {
                throw new EntityNotFoundException($"Cart with id: {id} does not exist.");
            }

            var items = await _repository.CartItems.FindByCartIdAsync(cart.Id);

            foreach (var item in items)
            {
                item.Offer.Seat.Status = Domain.Enums.SeatStatus.Booked;
                await _repository.Seats.UpdateAsync(item.Offer.Seat);
            }

            await _repository.SaveChangesAsync();
        }

        public async Task<CartDto> AddItemAsync(CartItemForCreateDto itemToCreate)
        {
            var cartItemEntity = _mapper.Map<CartItem>(itemToCreate);

            await _repository.CartItems.CreateAsync(cartItemEntity);

            var cart = await _repository.Carts.FindByIdAsync(itemToCreate.CartId);

            await _repository.SaveChangesAsync();

            var cartDto = _mapper.Map<CartDto>(cart);

            var totalDue = cartDto.CartItems.Sum(x => x.Offer.Price);

            return cartDto with
            {
                TotalDue = totalDue
            };
        }

        public async Task DeleteItemAsync(int cartId, int eventId, int seatId)
        {
            var cart = await _repository.Carts.FindByIdAsync(cartId);

            if (cart is null)
            {
                throw new EntityNotFoundException($"Cart {cartId} does not exist.");
            }

            var cartItems = await _repository.CartItems.FindByCartIdAsync(cartId);

            var itemToDelete = cartItems.FirstOrDefault(x => x.Offer != null &&
                x.Offer.Ticket != null &&
                x.Offer.Ticket.EventId == eventId &&
                x.Offer.SeatId == seatId);

            if (itemToDelete is null)
            {
                throw new EntityNotFoundException($"Cart: {cartId} does not have Seat with id: {seatId}.");
            }

            await _repository.CartItems.DeleteAsync(itemToDelete.Id);
        }
    }
}
