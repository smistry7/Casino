using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Domain.Models
{
    public record User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public decimal Balance { get; set; }
        public IEnumerable<GameRecord> GameRecords { get; set; } = Enumerable.Empty<GameRecord>();
    }

    public record GameRecord(Game Game, bool DidPlayerWin, decimal AmountStaked, decimal AmountWon);
    public enum Game
    {
        Blackjack
    }
}
