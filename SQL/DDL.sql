USE TicketingSystem_DatabaseFirst;

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Payment]') AND type in (N'U'))
    DROP TABLE [dbo].[Payment];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Offer]') AND type in (N'U'))
    DROP TABLE [dbo].[Offer];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Seat]') AND type in (N'U'))
    DROP TABLE [dbo].[Seat];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ticket]') AND type in (N'U'))
    DROP TABLE [dbo].[Ticket];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Event]') AND type in (N'U'))
    DROP TABLE [dbo].[Event];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Manifest]') AND type in (N'U'))
    DROP TABLE [dbo].[Manifest];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Venue]') AND type in (N'U'))
    DROP TABLE [dbo].[Venue];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
    DROP TABLE [dbo].[Customer];

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Address]') AND type in (N'U'))
    DROP TABLE [dbo].[Address];

CREATE TABLE [dbo].[Address](
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Details] NVARCHAR(500) NOT NULL,
    [Landmark] NVARCHAR(255) NULL,
    [Latitude] NVARCHAR(50) NULL,
    [Longtitude] NVARCHAR(50) NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [CreatedBy] NVARCHAR(MAX) NULL,
    [LastModifiedAt] DATETIME2 NULL,
    [LastModifiedBy] NVARCHAR(MAX) NULL
);

CREATE TABLE [dbo].[Customer](
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [FirstName] NVARCHAR(500) NOT NULL,
    [LastName] NVARCHAR(500) NULL,
    [PhoneNumber] NVARCHAR(25) NOT NULL,
    [Birthdate] DATE NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [CreatedBy] NVARCHAR(MAX) NULL,
    [LastModifiedAt] DATETIME2 NULL,
    [LastModifiedBy] NVARCHAR(MAX) NULL
);

CREATE TABLE [dbo].[Venue](
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(255) NOT NULL,
    [AddressId] INT NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [CreatedBy] NVARCHAR(MAX) NULL,
    [LastModifiedAt] DATETIME2 NULL,
    [LastModifiedBy] NVARCHAR(MAX) NULL,
    FOREIGN KEY (AddressId) REFERENCES Address(Id) ON DELETE CASCADE
);

CREATE TABLE [dbo].[Event](
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(255) NOT NULL,
    [Date] DATETIME2 NOT NULL,
    [Status] INT DEFAULT 0 NOT NULL,
    [VenueId] INT NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [CreatedBy] NVARCHAR(MAX) NULL,
    [LastModifiedAt] DATETIME2 NULL,
    [LastModifiedBy] NVARCHAR(MAX) NULL,
    FOREIGN KEY (VenueId) REFERENCES Venue(Id) ON DELETE CASCADE
);

CREATE TABLE [dbo].[Manifest](
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Title] NVARCHAR(255) NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [VenueId] INT NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [CreatedBy] NVARCHAR(MAX) NULL,
    [LastModifiedAt] DATETIME2 NULL,
    [LastModifiedBy] NVARCHAR(MAX) NULL,
    FOREIGN KEY (VenueId) REFERENCES Venue(Id) ON DELETE CASCADE
);

CREATE TABLE [dbo].[Ticket](
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Status] INT DEFAULT 2 NOT NULL,
    [EventId] INT NOT NULL,
    [CustomerId] INT NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [CreatedBy] NVARCHAR(MAX) NULL,
    [LastModifiedAt] DATETIME2 NULL,
    [LastModifiedBy] NVARCHAR(MAX) NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customer(Id),
    FOREIGN KEY (EventId) REFERENCES Event(Id) ON DELETE CASCADE
);

CREATE TABLE [dbo].[Seat](
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Number] INT NOT NULL,
    [Row] INT NOT NULL,
    [Type] INT NOT NULL,
    [StandardPrice] MONEY NULL,
    [ManifestId] INT NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [CreatedBy] NVARCHAR(MAX) NULL,
    [LastModifiedAt] DATETIME2 NULL,
    [LastModifiedBy] NVARCHAR(MAX) NULL,
    FOREIGN KEY (ManifestId) REFERENCES Manifest(Id) ON DELETE CASCADE
);

CREATE TABLE [dbo].[Offer](
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Title] NVARCHAR(50) NOT NULL,
    [Configurations] NVARCHAR(500) NULL,
    [SalePercentage] DECIMAL(18,2) DEFAULT 0 NOT NULL,
    [Price] DECIMAL(18,2) NOT NULL,
    [SeatId] INT NOT NULL,
    [TicketId] INT NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [CreatedBy] NVARCHAR(MAX) NULL,
    [LastModifiedAt] DATETIME2 NULL,
    [LastModifiedBy] NVARCHAR(MAX) NULL,
    FOREIGN KEY (SeatId) REFERENCES Seat(Id) ON DELETE CASCADE,
    FOREIGN KEY (TicketId) REFERENCES Ticket(Id)
);

CREATE TABLE [dbo].[Payment](
    [Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [PaymentDetails] NVARCHAR(250) NULL,
    [SourceCard] NVARCHAR(50) NOT NULL,
    [Amount] DECIMAL(18,2) NOT NULL,
    [TicketId] int NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [CreatedBy] NVARCHAR(MAX) NULL,
    [LastModifiedAt] DATETIME2 NULL,
    [LastModifiedBy] NVARCHAR(MAX) NULL,
    FOREIGN KEY (TicketId) REFERENCES Ticket(Id) ON DELETE CASCADE
);