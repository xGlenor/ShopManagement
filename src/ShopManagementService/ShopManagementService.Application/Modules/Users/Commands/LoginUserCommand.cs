using Mediator;
using ShopManagementService.Application.Common.Interfaces.Auth;
using ShopManagementService.Application.Common.Responses;

namespace ShopManagementService.Application.Modules.Users.Commands;

public record LoginUserCommand(string Email, string Password) : IRequest<Response<string>>;

class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Response<string>>
{
    private readonly IUserRepository _repository;

    public LoginUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }


    public ValueTask<Response<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}