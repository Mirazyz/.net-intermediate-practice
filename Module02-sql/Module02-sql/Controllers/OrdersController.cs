using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Domain.DTOs.Cart;
using TicketingSystem.Domain.DTOs.CartItem;
using TicketingSystem.Domain.Interfaces.Services;

namespace Module02_sql.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ICartService _cartService;

        public OrdersController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("carts/{cartId}")]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetCartByIdAsync(int cartId)
        {
            var cartItems = await _cartService.GetCartItemsAsync(cartId);

            return Ok(cartItems);
        }

        [HttpPost("carts/{cartId}")]
        public async Task<ActionResult<CartDto>> AddCartItemAsync(
            [FromRoute] int cartId,
            [FromRoute] CartItemForCreateDto itemToCreate)
        {
            if (cartId != itemToCreate.CartId)
            {
                return BadRequest($"Route id: {cartId} does not match with body {itemToCreate.CartId}");
            }

            var cart = await _cartService.AddCartItemAsync(itemToCreate);

            return cart;
        }

        [HttpDelete("carts/{cartId}/events/{eventId}/seats/{seatId}")]
        public async Task<ActionResult> DeleteSeatForEventAsync(int cartId, int eventId, int seatId)
        {
            await _cartService.DeleteItemAsync(cartId, eventId, seatId);

            return NoContent();
        }

        [HttpPut("carts/{cartId}/book")]
        public async Task<ActionResult> BookCartItemsAsync(int cartId)
        {
            await _cartService.BookItemsAsync(cartId);

            return NoContent();
        }
    }
}
