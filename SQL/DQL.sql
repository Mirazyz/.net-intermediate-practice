/* Get a list of all events and their venue information */
SELECT e.Name AS EventName, e.Date AS EventDate, v.Name AS VenueName, a.Details AS VenueAddress
FROM Event e
JOIN Venue v ON e.VenueId = v.Id
JOIN Address a ON v.AddressId = a.Id;

/* Get a list of customers and the number of tickets they purchased */
SELECT c.FirstName, c.LastName, COUNT(t.Id) AS TicketCount
FROM Customer c
JOIN Ticket t ON c.Id = t.CustomerId
GROUP BY c.FirstName, c.LastName;

/* Get the total revenue and seat count by event */
SELECT e.Id AS EventId, e.Name AS EventName, SUM(p.Amount) AS TotalRevenue, COUNT(s.Id) AS TotalSeats
FROM Event e
JOIN Ticket t ON e.Id = t.EventId
JOIN Payment p ON t.Id = p.TicketId
JOIN Offer o ON t.Id = o.TicketId
JOIN Seat s ON o.SeatId = s.Id
GROUP BY e.Id, e.Name;

/* Get a list of events with at least 10 available seats in their manifest */
SELECT e.Id AS EventId, e.Name AS EventName, SUM(p.Amount) AS TotalRevenue, COUNT(s.Id) AS TotalSeats
FROM Event e
JOIN Ticket t ON e.Id = t.EventId
JOIN Payment p ON t.Id = p.TicketId
JOIN Offer o ON t.Id = o.TicketId
JOIN Seat s ON o.SeatId = s.Id
GROUP BY e.Id, e.Name;

/* Get a list of customers who spent more than $100 on tickets */
SELECT c.Id, c.FirstName, c.LastName, SUM(p.Amount) AS TotalSpent
FROM Customer c
JOIN Ticket t ON c.Id = t.CustomerId
JOIN Payment p ON t.Id = p.TicketId
GROUP BY c.Id, c.FirstName, c.LastName
HAVING SUM(p.Amount) > 100;