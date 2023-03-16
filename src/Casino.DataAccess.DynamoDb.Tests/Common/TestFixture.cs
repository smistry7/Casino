using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Casino.DataAccess.DynamoDb.Tests.Common
{


    public class TestFixture
    {
        public TestFixture()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            Services = new ServiceCollection()
                .AddLogging(x => x.AddConsole())
                .AddDynamoDbDataStore(configuration);
        }

        public IServiceCollection Services { get; }
    }
}
