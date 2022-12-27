using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using Casino.Core.Models;
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
        [DynamoDBProperty("id")]
        [DynamoDBHashKey]
        public Guid Id { get; set; }

        [DynamoDBProperty("username")]
        public string Username { get; set; } = null!;

        [DynamoDBProperty("luck-coefficient")]
        public decimal LuckCoefficient { get; set; }

        [DynamoDBProperty("date-joined")]
        public DateTime DateJoined { get; set; }

        [DynamoDBProperty("balance")]
        public decimal Balance { get; set; }

        [DynamoDBProperty("game-records")]
        public List<GameRecord> GameRecords { get; set; } = new();
    }

    namespace Mapping
    {
        public class UserEntityMappings: Profile
        {
            public UserEntityMappings()
            {
                CreateMap<UserEntity, User>().ReverseMap();
            }
        }
    }
}
