CREATE TABLE [dbo].[User] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [Username]        VARCHAR (50)     NOT NULL,
    [Balance]         DECIMAL (18, 2)     NULL,
    [LuckCoefficient] DECIMAL (18, 2)      NULL,
    [DateJoined]      DATETIME         NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

