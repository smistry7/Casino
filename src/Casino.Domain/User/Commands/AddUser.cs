using Casino.Core.Interfaces.Repositories;
using FluentValidation;
using MediatR;

namespace Casino.Domain.User.Commands
{
    public class AddUser
    {
        public record Request(string Name, decimal Balance) : IRequest<Core.Models.User>;

        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty();
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
                var user = new Core.Models.User
                {
                    Id = Guid.NewGuid(),
                    Username = request.Name,
                    Balance = request.Balance,
                    DateJoined = DateTime.UtcNow,
                };
                var savedUser = await _userRepository.AddUser(user);

                return savedUser;
            }
        }
    }


}
