USE TicketingSystem_DatabaseFirst;

CREATE TRIGGER Payment_Inserted
ON [dbo].[Payment]
AFTER INSERT
AS
BEGIN
    UPDATE [dbo].[Ticket]
    SET Status = 1
    WHERE Id IN (SELECT TicketId FROM inserted)
END;

CREATE TRIGGER Payment_Deleted
ON [dbo].[Payment]
AFTER DELETE
AS
BEGIN
    UPDATE [dbo].[Ticket]
    SET Status = 2
    WHERE Id IN (SELECT TicketId FROM deleted)
END;