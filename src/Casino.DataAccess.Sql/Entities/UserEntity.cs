using System.ComponentModel.DataAnnotations;

namespace Casino.DataAccess.Sql.Entities
{
    public class UserAccountEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public decimal Balance { get; set; }
        public decimal LuckCoefficient { get; set; }
        public DateTime DateJoined { get; set; }
        public ICollection<GameRecordEntity> GameRecords { get; set; } = null!;
    }

    namespace Mapping
    {
        using AutoMapper;
        using Casino.Core.Models;

        public class UserEntityMappings : Profile
        {
            public UserEntityMappings()
            {
                CreateMap<User, UserAccountEntity>();
                CreateMap<UserAccountEntity, User>();
            }
        }
    }
}
