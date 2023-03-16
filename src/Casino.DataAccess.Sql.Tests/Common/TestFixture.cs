using Casino.DataAccess.Sql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Casino.DataAccess.Sql.Tests.Common
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
                .AddSqlServerDataStore(configuration);

        }

        public IServiceCollection Services { get; }
    }
}