USE TicketingSystem_DatabaseFirst;

CREATE NONCLUSTERED INDEX [IX_Event_VenueId]ON [dbo].[Event] ([VenueId]);
CREATE NONCLUSTERED INDEX [IX_Manifest_VenueId]ON [dbo].[Manifest] ([VenueId]);
CREATE UNIQUE INDEX [IX_Offer_SeatId]ON [dbo].[Offer] ([SeatId]);
CREATE NONCLUSTERED INDEX [IX_Offer_TicketId]ON [dbo].[Offer] ([TicketId]);
CREATE NONCLUSTERED INDEX [IX_Seat_ManifestId]ON [dbo].[Seat] ([ManifestId]);
CREATE NONCLUSTERED INDEX [IX_Ticket_CustomerId]ON [dbo].[Ticket] ([CustomerId]);
CREATE NONCLUSTERED INDEX [IX_Ticket_EventId]ON [dbo].[Ticket] ([EventId]);
CREATE UNIQUE INDEX [IX_Venue_AddressId]ON [dbo].[Venue] ([AddressId]);
CREATE UNIQUE INDEX [IX_Payment_TicketId] ON [dbo].[Payment]([TicketId]);