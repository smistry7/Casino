using System.ComponentModel.DataAnnotations;

namespace Casino.DataAccess.Sql.Entities
{
    public class GameRecordEntity
    {
        [Key]
        public Guid GameId { get; set; }
        public Guid UserId { get; set; }
        public string GameType { get; set; } = null!;
        public decimal AmountStaked { get; set; }
        public decimal AmountWon { get; set; }
        public decimal WinProbability { get; set; }
    }
}
