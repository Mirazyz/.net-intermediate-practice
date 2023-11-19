USE TicketingSystem_DatabaseFirst;

CREATE PROCEDURE [dbo].[GetCustomerEvents]
    @CustomerId INT
AS
BEGIN
    SELECT * FROM [Event]
	WHERE Id IN (SELECT e.Id
				FROM [Event] e
				INNER JOIN [Ticket] t ON e.Id = t.EventId
				INNER JOIN [Customer] c ON c.Id = t.CustomerId
				WHERE c.Id = @CustomerId);
END;

CREATE PROCEDURE [dbo].[GetTotalSalesByEvent]
    @EventId INT,
    @TotalSales DECIMAL(18,2) OUTPUT
AS
BEGIN
    SELECT @TotalSales = SUM(Payment.Amount)
    FROM Payment
    INNER JOIN Ticket ON Payment.TicketId = Ticket.Id
    WHERE Ticket.EventId = @EventId
END;

CREATE PROCEDURE [dbo].[GetSeatsAvailabilityInManifest]
    @ManifestId INT
AS
BEGIN
    SELECT 
        Seat.*, 
        CASE WHEN EXISTS (SELECT 1 FROM Offer WHERE Offer.SeatId = Seat.Id) THEN 0 ELSE 1 END AS IsAvailable
    FROM Seat
    WHERE Seat.ManifestId = @ManifestId
END;