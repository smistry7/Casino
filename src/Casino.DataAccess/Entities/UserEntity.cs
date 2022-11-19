using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DataAccess.Sql.Entities
{
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public decimal Balance { get; set; }
        public decimal LuckCoefficient { get; set; }
        public DateTimeOffset DateJoined { get; set; }
        public ICollection<GameRecordEntity> Games { get; set; } = null!;
    }

    namespace Mapping
    {
        using AutoMapper;
        using Casino.Core.Models;

        public class UserEntityMappings : Profile
        {
            public UserEntityMappings()
            {
                CreateMap<User, UserEntity>();
                CreateMap<UserEntity, User>();
            }
        }
    }
}
