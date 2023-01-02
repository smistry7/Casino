using AutoMapper;
using Casino.Api.Dto;
using Casino.Core.Models;
using Casino.Domain.User.Commands;
using Casino.Domain.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Casino.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(
            IMediator mediator,
            IMapper mapper
        )
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<UserDto> Get([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetUser.Request(id));
            return _mapper.Map<UserDto>(response);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<User> PostUser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            return await _mediator.Send(new AddUser.Request(user.Username, user.Balance, user.PasswordHash));
        }

    }
}
