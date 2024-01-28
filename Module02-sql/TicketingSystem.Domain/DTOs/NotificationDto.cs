namespace TicketingSystem.Domain.DTOs
{
    public record NotificationDto(Guid Id, OperationType Operation, DateTime Timestamp, NotificationParameters Parameters, string Content);

    public record NotificationParameters(string CustomerName, string CustomerEmail);

    public enum OperationType
    {
        None = 0,
        PaymentSucceeded = 1,
        PaymentFailed = 2
    }
}
