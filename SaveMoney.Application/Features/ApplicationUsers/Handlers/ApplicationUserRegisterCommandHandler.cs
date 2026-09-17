using MediatR;
using SaveMoney.Application.Features.ApplicationUsers.Commands;
using SaveMoney.Domain.Account;
using SaveMoney.Domain.Entities;

namespace SaveMoney.Application.Features.ApplicationUsers.Handlers
{
    public class ApplicationUserRegisterCommandHandler : IRequestHandler<ApplicationUserRegisterCommand, string>
    {
        private readonly IAuthenticate _authenticate;

        public ApplicationUserRegisterCommandHandler(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }

        public async Task<string> Handle(ApplicationUserRegisterCommand request, CancellationToken cancellationToken)
        {
            var user = await _authenticate.RegisterUser(request.Email, request.Password);
            return user;
        }
    }
}
