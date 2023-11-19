USE TicketingSystem_DatabaseFirst;

INSERT INTO Address (Details, Latitude, Longtitude, CreatedAt)
VALUES ('123 Test St', '50.0000', '100.0000', GETDATE());

INSERT INTO Customer (FirstName, PhoneNumber, Birthdate, CreatedAt)
VALUES ('John Doe', '1234567890', '1980-01-01', GETDATE());

INSERT INTO Venue (Name, AddressId, CreatedAt)
VALUES ('Test Venue', (SELECT MAX(Id) FROM Address), GETDATE());

INSERT INTO Event (Name, Date, VenueId, CreatedAt)
VALUES ('Test Event', GETDATE(), (SELECT MAX(Id) FROM Venue), GETDATE());

INSERT INTO Manifest (Title, VenueId, CreatedAt)
VALUES ('Test Manifest', (SELECT MAX(Id) FROM Venue), GETDATE());

INSERT INTO Seat (Number, Row, Type, ManifestId, CreatedAt)
VALUES (1, 1, 0, (SELECT MAX(Id) FROM Manifest), GETDATE());

INSERT INTO Ticket (Status, EventId, CustomerId, CreatedAt)
VALUES (2, (SELECT MAX(Id) FROM Event), (SELECT MAX(Id) FROM Customer), GETDATE());

INSERT INTO Offer (Title, Price, SeatId, CreatedAt)
VALUES ('Test Offer', 100.00, (SELECT MAX(Id) FROM Seat), GETDATE());

INSERT INTO Payment (PaymentDetails, SourceCard, Amount, TicketId, CreatedAt)
VALUES ('Test Payment', '1234567812345678', 100.00, (SELECT MAX(Id) FROM Ticket), GETDATE());