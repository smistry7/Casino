using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Casino.Core.Interfaces.Repositories;
using Casino.Core.Models;
using Casino.DataAccess.DynamoDb.Entities;
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

        public async Task<GameRecord> AddGameRecord(GameRecord gameRecord)
        {
            var user = await DynamoDBContext.LoadAsync<UserEntity>(gameRecord.UserId);
            user.GameRecords.Add(gameRecord);
            await DynamoDBContext.SaveAsync(user);
            return gameRecord;
        }
    }
}
