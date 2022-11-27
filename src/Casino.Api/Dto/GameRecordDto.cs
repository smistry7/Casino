using AutoMapper;
using Casino.Core.Models;
using Casino.Domain.GameRecord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Api.Dto
{
    public record GameRecordDto
    {
        public Guid UserId { get; set; }
        public Game Game { get; set; }
        public bool DidPlayerWin { get; set; }
        public decimal AmountStaked { get; set; }
        public decimal AmountWon { get; set; }
        public decimal WinProbability { get; set; }
    }

    namespace Mapping
    {
        public class GameRecordDtoMapping : Profile
        {
            public GameRecordDtoMapping()
            {
                CreateMap<GameRecordDto, AddRecord.Request>();
            }
        }
    }
}
