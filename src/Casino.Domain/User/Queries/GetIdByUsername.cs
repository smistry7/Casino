using Casino.Core.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Domain.User.Queries
{
    public class GetIdByUsername
    {
        public record Request(string Username) : IRequest<Guid>;

        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.Username).NotEmpty().WithMessage("Please pass a valid username");
            }
        }

        public class Handler : IRequestHandler<Request, Guid>
        {
            private readonly IUserRepository _userRepository;
            public Handler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<Guid> Handle(Request request, CancellationToken cancellationToken)
            {
                var validator = new Validator();
                await validator.ValidateAndThrowAsync(request);
                return await _userRepository.GetIdFromUserName(request.Username);
            }
        }
    }
}
