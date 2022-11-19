namespace Casino.Core.Models
{
    public record GameRecord(
        Guid GameId,
        Game Game, 
        bool DidPlayerWin, 
        decimal AmountStaked, 
        decimal AmountWon, 
        decimal WinProbability
    );

    public enum Game
    {
        Blackjack
    }
}
