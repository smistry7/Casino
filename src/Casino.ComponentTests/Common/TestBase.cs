using Casino.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.ComponentTests.Common
{
    public class TestBase : IClassFixture<WebApplicationFactory<Program>>
    {
        protected readonly WebApplicationFactory<Program> Factory;
        public TestBase(WebApplicationFactory<Program> factory)
        {
            Factory = factory;
        }

    }
}
