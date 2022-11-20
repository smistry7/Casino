using Casino.Core.Models;
using Casino.Domain.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Casino.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<User> Get([FromRoute] Guid id) => await _mediator.Send(new GetUser.Request(id));


    }
}
