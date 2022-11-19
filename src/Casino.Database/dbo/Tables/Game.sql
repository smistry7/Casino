CREATE TABLE [dbo].[Game] (
    [GameId]         UNIQUEIDENTIFIER NOT NULL,
    [UserId]         UNIQUEIDENTIFIER NOT NULL,
    [GameType]       VARCHAR (50)     NOT NULL,
    [AmountStaked]   MONEY            NOT NULL,
    [AmountWon]      MONEY            NOT NULL,
    [WinProbability] DECIMAL (18)     NOT NULL,
    PRIMARY KEY CLUSTERED ([GameId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

