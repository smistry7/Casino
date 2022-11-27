using Casino.Core.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using System.Security.Cryptography.X509Certificates;

namespace Casino.Domain.User.Queries
{
    public class GetUser
    {
        public record Request(Guid Id) : IRequest<Core.Models.User>;

        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Please pass a valid guid");
            }
        }

        public class Handler : IRequestHandler<Request, Core.Models.User>
        {
            private readonly IUserRepository _userRepository;
            public Handler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<Core.Models.User> Handle(Request request, CancellationToken cancellationToken)
            {
                var validator = new Validator();
                await validator.ValidateAndThrowAsync(request);
                return await _userRepository.GetUser(request.Id);
            }
        }
    }
}
