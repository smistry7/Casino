using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace Casino.DataAccess.DynamoDb.Repositories
{
    public class BaseRepository
    {
        protected readonly AmazonDynamoDBClient AmazonDynamoDBClient;
        protected readonly DynamoDBContext DynamoDBContext;

        public BaseRepository()
        {

        }

        
    }
}