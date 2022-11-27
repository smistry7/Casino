using Casino.Api.Dto;
using Casino.Core.Models;
using Refit;

namespace Casino.ComponentTests.WebApiClient
{
    public interface IGameRecordApi : ICasinoApi
    {
        [Post("/api/game-record")]
        Task<ApiResponse<GameRecord>> PostGameRecordResponse([Body] GameRecordDto id);
    }
}
