using AutoMapper;
using Casino.Core.Models;
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
        public bool DidPlayerWin { get; set; }
        public UserAccountEntity UserAccount { get; set; } = null!;
    }

    namespace Mappings
    {
        public class GameRecordMappings : Profile
        {
            public GameRecordMappings()
            {
                CreateMap<GameRecordEntity, GameRecord>();
                CreateMap<GameRecord, GameRecordEntity>();
            }
        }
    }
}
