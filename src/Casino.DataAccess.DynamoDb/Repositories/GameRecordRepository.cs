using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Casino.Core.Interfaces.Repositories;
using Casino.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DataAccess.DynamoDb.Repositories
{
    public class GameRecordRepository : BaseRepository, IGameRecordRepository
    {
        public GameRecordRepository(IAmazonDynamoDB amazonDynamoDB, IDynamoDBContext dynamoDBContext) 
            : base(amazonDynamoDB, dynamoDBContext)
        {
        }

        public Task<GameRecord> AddGameRecord(GameRecord gameRecord)
        {
            throw new NotImplementedException();
        }
    }
}
