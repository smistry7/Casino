using AutoMapper;
using Casino.DataAccess.Sql.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Casino.DataAccess.Sql.Tests.Common
{
    public abstract class TestBase : IClassFixture<TestFixture>
    {
        public TestBase(TestFixture testFixture)
        {
            Services = testFixture.Services.BuildServiceProvider();
            Mapper = Services.GetRequiredService<IMapper>();
            Logger = Services.GetRequiredService<ILoggerFactory>();
            CasinoDataContext = Services.GetRequiredService<CasinoDataContext>();
        }
        protected ServiceProvider Services { get; }
        protected IMapper Mapper { get; }
        protected ILoggerFactory Logger { get; }
        protected CasinoDataContext CasinoDataContext { get; }
    }
}