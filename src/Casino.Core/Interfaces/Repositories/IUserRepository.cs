using Casino.Core.Models;

namespace Casino.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User> GetUser(Guid id);
        Task<User> UpdateUser(User user);
        Task<Guid> GetIdFromUserName(string username);
    }
}