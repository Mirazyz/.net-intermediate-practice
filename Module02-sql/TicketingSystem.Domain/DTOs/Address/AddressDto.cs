using TicketingSystem.Domain.DTOs.Venue;

namespace TicketingSystem.Domain.DTOs.Address
{
    public record AddressDto(
        int Id,
        string Detials,
        string Landmark,
        string Latitude,
        string Longtitude,
        VenueDto Venue);
}
