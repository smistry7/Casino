using Casino.DataAccess.Sql.Data;
using System;
using Casino.Core.Interfaces.Repositories;
using Casino.DataAccess.Sql.Entities;
using Casino.Core.Models;
using AutoMapper;

namespace Casino.DataAccess.Sql.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CasinoDataContext _casinoDataContext;
        private readonly IMapper _mapper;

        public UserRepository(CasinoDataContext casinoDataContext, IMapper mapper)
        {
            _casinoDataContext = casinoDataContext;
            _mapper = mapper;
        }

        public async Task<User> GetUser(Guid id)
        {
            var result = await _casinoDataContext.Users.FindAsync(keyValues: id) ?? throw new Exception("User not found");
            return _mapper.Map<User>(result);
        }

        public async Task<User> AddUser(User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            var result = await _casinoDataContext.Users.AddAsync(userEntity);
            await _casinoDataContext.SaveChangesAsync();
            return _mapper.Map<User>(result.Entity);
        }
        public async Task<User> UpdateUser(User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            _casinoDataContext.Users.Update(userEntity);
            await _casinoDataContext.SaveChangesAsync();
            return user;
        }
    }
}
