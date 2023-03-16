using AutoFixture;
using Casino.Api;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Casino.ComponentTests.Common
{
    public class TestBase : IClassFixture<WebApplicationFactory<Program>>
    {
        protected readonly WebApplicationFactory<Program> Factory;
        protected readonly ITestOutputHelper OutputHelper;
        protected readonly Fixture Fixture;
        public TestBase(WebApplicationFactory<Program> factory, ITestOutputHelper outputHelper)
        {
            Factory = factory.WithWebHostBuilder(host =>
            {
                host.ConfigureTestServices(services =>
                {
                    services.AddAuthentication("Test")
                    .AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>("Test", null);
                });
            });
            OutputHelper = outputHelper;
            Fixture = new Fixture();
        }

        public void LogErrorResponse<T>(ApiResponse<T> response)
        {
            var content = response.Error?.Content;
            if (!string.IsNullOrEmpty(content))
            {
                OutputHelper.WriteLine(content);
            }
        }

        protected HttpClient GetAuthenticatedClient()
        {
            var client = Factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Test", "true");
            return client;
        }
    }
}
