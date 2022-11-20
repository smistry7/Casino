using Casino.Api;
using Microsoft.AspNetCore.Mvc.Testing;
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
        public TestBase(WebApplicationFactory<Program> factory, ITestOutputHelper outputHelper)
        {
            Factory = factory;
            OutputHelper = outputHelper;
        }

        public void LogErrorResponse<T>(ApiResponse<T> response)
        {
            var content = response.Error?.Content;
            if (!string.IsNullOrEmpty(content))
            {
                OutputHelper.WriteLine(content);
            }
        }
    }
}
