CREATE TABLE [dbo].[GameRecord] (
    [GameId]         UNIQUEIDENTIFIER NOT NULL,
    [UserId]         UNIQUEIDENTIFIER NOT NULL,
    [GameType]       VARCHAR (50)     NOT NULL,
    [AmountStaked]   MONEY            NOT NULL,
    [AmountWon]      MONEY            NOT NULL,
    [WinProbability] DECIMAL (18, 2)     NOT NULL,
    [DidPlayerWin] BIT NOT NULL, 
    PRIMARY KEY CLUSTERED ([GameId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserAccount] ([Id])
);

