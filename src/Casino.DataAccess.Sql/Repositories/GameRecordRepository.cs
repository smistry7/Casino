using AutoMapper;
using Casino.Core.Interfaces.Repositories;
using Casino.Core.Models;
using Casino.DataAccess.Sql.Data;
using Casino.DataAccess.Sql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DataAccess.Sql.Repositories
{
    public class GameRecordRepository : IGameRecordRepository
    {
        private readonly CasinoDataContext _casinoDataContext;
        private readonly IMapper _mapper;

        public GameRecordRepository(CasinoDataContext casinoDataContext, IMapper mapper)
        {
            _casinoDataContext = casinoDataContext;
            _mapper = mapper;
        }

        public async Task<GameRecord> AddGameRecord(GameRecord gameRecord)
        {
            var gameRecordEntity = _mapper.Map<GameRecordEntity>(gameRecord);
            var result = await _casinoDataContext.GameRecord.AddAsync(gameRecordEntity);
            await _casinoDataContext.SaveChangesAsync();
            return _mapper.Map<GameRecord>(result.Entity);
        }

    }
}
