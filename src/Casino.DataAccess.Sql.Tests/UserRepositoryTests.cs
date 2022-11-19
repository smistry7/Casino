using Casino.Core.Interfaces.Repositories;
using Casino.DataAccess.Sql.Tests.Common;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Casino.ComponentTests
{
    public class UserRepositoryTests : TestBase
    {
        public UserRepositoryTests(TestFixture testFixture) : base(testFixture)
        {
        }

        [Fact]
        public async Task GetUser_ReturnsGameInfo()
        {
            var userRepo = Services.GetService<IUserRepository>();
            var user = await userRepo.GetUser(KnownUsers.User1);
            user.GameRecords.Should().NotBeEmpty();
        }
    }
}