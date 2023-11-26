using AutoMapper;
using TicketingSystem.Domain.DTOs.Cart;

namespace TicketingSystem.Domain.Mappings
{
    public class Cart : Profile
    {
        public Cart()
        {
            CreateMap<Cart, CartDto>();
            CreateMap<CartDto, Cart>();
            CreateMap<CartForCreateDto, Cart>();
        }
    }
}
