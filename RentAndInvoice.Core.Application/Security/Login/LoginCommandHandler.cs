using MediatR;
using RentAndInvoice.Core.Application.Abstractions;
using RentAndInvoice.Core.Domain.Entities.Security;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Application.Security.Login;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public Task<LoginResponse> Handle(Login.LoginCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "The request is null.");
        }

        var user = _userRepository.GetByCredendialsAsync(request.Email, request.Password);

        if (user is null)
        {
            throw new UserNotFoundException(request.Email);
        }

        string token = _jwtProvider.Generate(user);

        LoginResponse loginResponse = new LoginResponse(token);

        return Task.FromResult(loginResponse);
    }
}
