using AutoMapper;
using Casino.Api.Dto;
using Casino.Core.Models;
using Casino.Domain.GameRecord.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Casino.Api.Controllers
{
    [ApiController]
    [Route("api/game-record")]
    public class GameRecordController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GameRecordController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public async Task<GameRecord> PostRecord([FromBody] GameRecordDto user)
        {
            var request = _mapper.Map<AddRecord.Request>(user);
            return await _mediator.Send(request);
        }

    }
}
