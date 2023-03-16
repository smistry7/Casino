using Casino.Api;
using Casino.ComponentTests.Common;
using Casino.ComponentTests.WebApiClient;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.ComponentTests.Extensions;
using Xunit.Abstractions;
using Casino.Core.Models;
using AutoFixture;
using Casino.Api.Dto;

namespace Casino.ComponentTests.Controller
{
    public class UserControllerTests : TestBase
    {
        private readonly IUserApi _typedClient;
        public UserControllerTests(WebApplicationFactory<Program> factory, ITestOutputHelper outputHelper) : base(factory, outputHelper)
        {
            var client = GetAuthenticatedClient();
            _typedClient = new ApiClientFactory(client).BuildApi<IUserApi>();
        }

        [Fact]
        public async Task UserController_Get_ReturnsSuccessfully()
        {
            // arrange 
            // act
            var response = await _typedClient.GetUserResponse(KnownUsers.User1);
            // assert
            LogErrorResponse(response);
            response.Should().BeOkResponse();
        }

        [Fact]
        public async Task UserController_Post_ReturnsSuccessfully()
        {
            var user = Fixture.Create<UserDto>();

            var response = await _typedClient.PostUserResponse(user);

            response.Content!.Balance.Should().Be(user.Balance);
        }
    }
}
