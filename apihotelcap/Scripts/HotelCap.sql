CREATE DATABASE HotelCap

GO

USE HotelCap

CREATE TABLE [Client] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(80) NOT NULL,
    [CPF] nvarchar(15) NOT NULL,
	[Hash] nvarchar(30) NOT NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [BedroomType] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NOT NULL,
    [Value] float NOT NULL,
    CONSTRAINT [PK_BedroomType] PRIMARY KEY ([Id]),
);

GO

CREATE TABLE [BedRoom] (
    [Id] int NOT NULL IDENTITY,
    [Floor] int NOT NULL,
    [NoQuarto] int NOT NULL,
    [Situation] char NOT NULL,
    [IdBedroomType] int NOT NULL,
    CONSTRAINT [PK_Operacao] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Bedroom_BedroomType_IdBedroomType] FOREIGN KEY ([IdBedroomType]) REFERENCES [BedroomType] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Occupation] (
    [Id] int NOT NULL IDENTITY,
    [QtdeDiarys] int NOT NULL,
    [Date] datetime2 NOT NULL,
    [Situation] char NOT NULL,
	[IdBedroom] int NOT NULL,
    [IdClient] int NOT NULL,
    CONSTRAINT [PK_Occupation] PRIMARY KEY ([Id]),
);

CREATE INDEX [IX_BedRoom_IIdBedroomType] ON [BedRoom] ([IdBedroomType]);

GO

