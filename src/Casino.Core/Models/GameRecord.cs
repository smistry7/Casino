﻿namespace Casino.Core.Models
{
    public record GameRecord
    {
        public Guid GameId { get; set; }
        public Guid UserId { get; set; }
        public Game GameType { get; set; }
        public bool DidPlayerWin { get; set; }
        public decimal AmountStaked { get; set; }
        public decimal AmountWon { get; set; }
        public decimal WinProbability { get; set; }
    }

    public enum Game
    {
        Blackjack
    }
}
