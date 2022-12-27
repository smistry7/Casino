using Casino.Core.Interfaces.Repositories;
using Casino.Core.Models;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Domain.GameRecord.Commands
{
    public class AddRecord
    {
        public record Request(
            Guid UserId,
            Game Game,
            bool DidPlayerWin,
            decimal AmountStaked,
            decimal AmountWon,
            decimal WinProbability
        ) : IRequest<Core.Models.GameRecord>;

        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.AmountStaked).NotEqual(0);
                RuleFor(x => x.WinProbability).InclusiveBetween(0, 1);
            }
        }

        public class Handler : IRequestHandler<Request, Core.Models.GameRecord>
        {
            private readonly IGameRecordRepository _gameRecordRepository;
            private readonly IUserRepository _userRepository;

            public Handler(IGameRecordRepository gameRecordRepository, IUserRepository userRepository)
            {
                _gameRecordRepository = gameRecordRepository;
                _userRepository = userRepository;
            }

            public async Task<Core.Models.GameRecord> Handle(Request request, CancellationToken cancellationToken)
            {
                var validator = new Validator();
                await validator.ValidateAndThrowAsync(request);
                var game = new Core.Models.GameRecord
                {
                    GameId = Guid.NewGuid(),
                    UserId = request.UserId,
                    GameType = request.Game,
                    DidPlayerWin = request.DidPlayerWin,
                    AmountStaked = request.AmountStaked,
                    AmountWon = request.AmountWon,
                    WinProbability = request.WinProbability
                };

                var user = await _userRepository.GetUser(request.UserId);

                var gameRecordsCount = user.GameRecords?.Count ?? 0;

                var newLuckCoefficient = ((user.LuckCoefficient * gameRecordsCount) + request.WinProbability) 
                    / (gameRecordsCount + 1);
                user.LuckCoefficient = newLuckCoefficient;

                await _userRepository.UpdateUser(user);
                var savedGame = await _gameRecordRepository.AddGameRecord(game);
                return savedGame;
            }
        }
    }
}
