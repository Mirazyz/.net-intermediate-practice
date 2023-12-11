using AutoMapper;
using TicketingSystem.Domain.DTOs.CartItem;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Domain.Mappings
{
    public class CartItemMapping : Profile
    {
        public CartItemMapping()
        {
            CreateMap<CartItem, CartItemDto>();
            CreateMap<CartItemDto, CartItem>();
            CreateMap<CartItemForCreateDto, CartItem>();
        }
    }
}
