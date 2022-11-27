using Casino.Core.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.ComponentTests.WebApiClient
{
    public interface IUserApi : ICasinoApi
    {
        [Get("/api/users/{id}")]
        Task<ApiResponse<User>> GetUserResponse(Guid id);
        [Post("/api/users")]
        Task<ApiResponse<User>> PostUserResponse([Body] User user);
    }
}
