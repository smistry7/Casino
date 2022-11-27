using Casino.Api;
using Casino.ComponentTests.Common;
using Casino.ComponentTests.WebApiClient;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Casino.ComponentTests.Extensions;
using Xunit.Abstractions;
using AutoFixture;
using Casino.Api.Dto;

namespace Casino.ComponentTests.Controller
{
    public class GameRecordControllerTests : TestBase
    {
        private readonly IGameRecordApi _typedClient;
        public GameRecordControllerTests(WebApplicationFactory<Program> factory, ITestOutputHelper outputHelper) : base(factory, outputHelper)
        {
            var client = Factory.CreateClient();
            _typedClient = new ApiClientFactory(client).BuildApi<IGameRecordApi>();
        }

        [Fact]
        public async Task GameRecord_Post_SavesCorrectly()
        {
            var input = Fixture.Build<GameRecordDto>()
                .With(x => x.UserId, KnownUsers.User1)
                .With(x=>x.WinProbability,(decimal) 0.5)
                .Create();
            var response = await _typedClient.PostGameRecordResponse(input);

            response.Should().BeOkResponse();
            response.Content!.AmountStaked.Should().Be(input.AmountStaked);
        }
    }
}
