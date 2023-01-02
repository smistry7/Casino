using Casino.DataAccess.Sql.Data;
using System;
using Casino.Core.Interfaces.Repositories;
using Casino.DataAccess.Sql.Entities;
using Casino.Core.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
            var result = await _casinoDataContext.UserAccount
                .AsNoTracking()
                .Include(x => x.GameRecords)
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("User not found");
            return _mapper.Map<User>(result);
        }

        public async Task<User> AddUser(User user)
        {
            var userEntity = _mapper.Map<UserAccountEntity>(user);
            var result = await _casinoDataContext.UserAccount.AddAsync(userEntity);
            await _casinoDataContext.SaveChangesAsync();
            return _mapper.Map<User>(result.Entity);
        }
        public async Task<User> UpdateUser(User user)
        {
            var userEntity = _mapper.Map<UserAccountEntity>(user);
            _casinoDataContext.UserAccount.Update(userEntity);
            await _casinoDataContext.SaveChangesAsync();
            return user;
        }

        public async Task<Guid> GetIdFromUserName(string username)
        {
            var result = await _casinoDataContext.UserAccount
                .AsNoTracking()
                .Include(x => x.GameRecords)
                .FirstOrDefaultAsync(x => x.Username == username)
                ?? throw new Exception("user not found");

            return result.Id;
        }
    }
}
