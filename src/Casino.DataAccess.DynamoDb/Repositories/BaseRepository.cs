using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace Casino.DataAccess.DynamoDb.Repositories
{
    public class BaseRepository
    {
        protected readonly IAmazonDynamoDB AmazonDynamoDBClient;
        protected readonly IDynamoDBContext DynamoDBContext;

        public BaseRepository(
            IAmazonDynamoDB amazonDynamoDB,
            IDynamoDBContext dynamoDBContext
            )
        {
            AmazonDynamoDBClient = amazonDynamoDB;
            DynamoDBContext = dynamoDBContext;
        }
    }
}