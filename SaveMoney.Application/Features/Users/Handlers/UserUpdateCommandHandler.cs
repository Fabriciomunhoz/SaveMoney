using MediatR;
using SaveMoney.Application.Features.Users.Commands;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;

namespace SaveMoney.Application.Features.Users.Handlers
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UserUpdateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new ApplicationException($"Error could not be found");

            user.Update(request.Name, request.Email, request.Age, request.Cpf, request.Password, request.IdRole);
            return await _userRepository.UpdateAsync(user);
        }
    }
}
