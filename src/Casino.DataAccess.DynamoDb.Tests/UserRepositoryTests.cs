using AutoFixture;
using Casino.Core.Interfaces.Repositories;
using Casino.Core.Models;
using Casino.DataAccess.DynamoDb.Tests.Common;
using FluentAssertions;
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

            result.Should().NotBeNull();
            result.Id.Should().Be(knownUser);
        }

        [Fact]
        public async Task AddUserWorksCorrectly()
        {
            var newUser = new Fixture
        }
    }
}
