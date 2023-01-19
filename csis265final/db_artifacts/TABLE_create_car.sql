CREATE TABLE [dbo].[Car] (
    [Id]     INT             NOT NULL IDENTITY,
    [Make]   VARCHAR (50)    NOT NULL,
    [Model]  VARCHAR (50)    NOT NULL,
	[Color]  VARCHAR (50)	 NOT NULL,
    [Weight] DECIMAL (18, 2) NOT NULL,
    [Mpg]    INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);