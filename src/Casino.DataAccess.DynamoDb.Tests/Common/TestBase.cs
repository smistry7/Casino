using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Casino.DataAccess.DynamoDb.Tests.Common
{
    public class TestBase : IClassFixture<TestFixture>
    {
        public TestBase(TestFixture testFixture)
        {
            Services = testFixture.Services.BuildServiceProvider();
            Mapper = Services.GetRequiredService<IMapper>();
            Logger = Services.GetRequiredService<ILoggerFactory>();
            DynamoContext = Services.GetRequiredService<IDynamoDBContext>();
        }
        protected ServiceProvider Services { get; }
        protected IMapper Mapper { get; }
        protected ILoggerFactory Logger { get; }
        protected IDynamoDBContext DynamoContext { get; }
    }
}
