using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using Casino.Core.Interfaces.Repositories;
using Casino.Core.Models;
using Casino.DataAccess.DynamoDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DocumentModel;

namespace Casino.DataAccess.DynamoDb.Repositories
{
    public class UserRepository :  BaseRepository, IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(
            IAmazonDynamoDB amazonDynamoDB, 
            IDynamoDBContext dynamoDBContext,
            IMapper mapper) 
            : base(amazonDynamoDB, dynamoDBContext)
        {
            _mapper = mapper;
        }

        public async Task<User> AddUser(User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            await DynamoDBContext.SaveAsync(userEntity);
            return user;
        }

        public async Task<Guid> GetIdFromUserName(string username)
        {
            var user = await DynamoDBContext
                .ScanAsync<UserEntity>(new List<ScanCondition>() { new ScanCondition(nameof(UserEntity.Username), ScanOperator.Equal, username) })
                .GetRemainingAsync();
            return user.Single().Id;
        }
        public async Task<User> GetUser(Guid id)
        {
            var userEntity = await DynamoDBContext.LoadAsync<UserEntity>(id);
            return _mapper.Map<User>(userEntity);
        }

        public async Task<User> UpdateUser(User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            await DynamoDBContext.SaveAsync(userEntity);
            return user;
        }
    }
}
