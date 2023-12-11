using AutoMapper;
using TicketingSystem.Domain.DTOs.Cart;

namespace TicketingSystem.Domain.Mappings
{
    public class CartMapping : Profile
    {
        public CartMapping()
        {
            CreateMap<CartMapping, CartDto>();
            CreateMap<CartDto, CartMapping>();
            CreateMap<CartForCreateDto, CartMapping>();
        }
    }
}
