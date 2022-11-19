using Casino.Core.Models;

namespace Casino.Core.Interfaces.Repositories
{
    public interface IGameRecordRepository
    {
        Task<GameRecord> AddGameRecord(GameRecord gameRecord);
    }
}