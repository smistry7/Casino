using AutoFixture;
using Casino.Core.Interfaces.Repositories;
using Casino.Core.Models;
using Casino.DataAccess.Sql.Tests.Common;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Casino.DataAccess.Sql.Tests
{
    public class UserRepositoryTests : TestBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IFixture _fixture;
        public UserRepositoryTests(TestFixture testFixture) : base(testFixture)
        {
            _userRepository = Services.GetRequiredService<IUserRepository>();
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetUser_ReturnsGameInfo()
        {
            var user = await _userRepository.GetUser(KnownUsers.User1);
            user.GameRecords.Should().NotBeEmpty();
        }

        [Fact]
        public async Task AddUser_ReturnsCorrectly()
        {
            var user = _fixture.Create<User>();
            var savedUser = await _userRepository.AddUser(user);
            savedUser.Username.Should().Be(user.Username);
        }

        [Fact]
        public async Task UpdateUser_ReturnsCorrectly()
        {
            var user = await _userRepository.GetUser(KnownUsers.User1);
            user.LuckCoefficient = (decimal)0.01;
            var result = await _userRepository.UpdateUser(user);

            result.LuckCoefficient.Should().Be((decimal)0.01);
        }
    }
}