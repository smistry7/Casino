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

namespace Casino.ComponentTests.Controller
{
    public class UserControllerTests : TestBase
    {
        public UserControllerTests(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task UserController_Get_ReturnsSuccessfully()
        {
            // arrange 
            var client = Factory.CreateClient();
            var typedClient = new ApiClientFactory(client).BuildUserApi();
            // act
            var response = await typedClient.GetUserResponse(Guid.Parse("FA20CD73-D1B0-49D9-83AE-00BC661A607D"));
            // assert
            response.Should().BeOkResponse();
        }
    }
}
