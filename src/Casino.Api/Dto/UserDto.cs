using AutoMapper;
using Casino.Core.Extensions;
using Casino.Core.Models;

namespace Casino.Api.Dto
{
    public record UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public decimal Balance { get; set; }
        public DateTime DateJoined { get; set; }
        public decimal LuckCoefficient { get; set; }
        public ICollection<GameRecord> GameRecords { get; set; } = null!;
    }

    namespace Mapping
    {
        public class UserDtoMapping : Profile
        {
            public UserDtoMapping()
            {
                CreateMap<UserDto, User>()
                    .ForMember(x=>x.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash.Encrypt()));
                CreateMap<User, UserDto>()
                    .ForMember(x => x.PasswordHash, opt => opt.Ignore());
            }
        }
    }
}
