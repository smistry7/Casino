using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DataAccess.DynamoDb.Entities
{
    [DynamoDBTable("users")]
    public record UserEntity
    {
        [DynamoDBHashKey("id")]
        public Guid Id { get; set; }

        [DynamoDBRangeKey("username")]
        public string Username { get; set; } = null!;
        
        [DynamoDBProperty("luck-coefficient")]
        public decimal LuckCoefficient { get; set; }
        
        [DynamoDBProperty("date-joined")]
        public DateTime DateJoined { get; set; }
        
        [DynamoDBProperty("balance")]
        public decimal Balance { get; set; }

    }
}
