using AutoFixture;
using Casino.Core.Interfaces.Repositories;
using Casino.Core.Models;
using Casino.DataAccess.DynamoDb.Tests.Common;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DataAccess.DynamoDb.Tests
{
    public class UserRepositoryTests : TestBase
    {
        public UserRepositoryTests(TestFixture testFixture) : base(testFixture)
        {

        }

        [Fact]
        public async Task GetUserWorksCorrectly()
        {
            var knownUser = Guid.Parse("FA20CD73-D1B0-49D9-83AE-00BC661A607D");
            var userRepository = Services.GetRequiredService<IUserRepository>();
            var result = await userRepository.GetUser(knownUser);

            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Id.Should().Be(knownUser);
            }
        }

        [Fact]
        public async Task AddUserWorksCorrectly()
        {
            var newUser = new User()
            {
                Username = "smistry7",
                Balance = 400,
                GameRecords = new List<GameRecord>()
            };

            var userRepository = Services.GetRequiredService<IUserRepository>();
            var result = await userRepository.AddUser(newUser);

            using (new AssertionScope())
            {
                result.Username.Should().Be(newUser.Username);
                result.Balance.Should().Be(newUser.Balance);
            }
        }
    }
}
