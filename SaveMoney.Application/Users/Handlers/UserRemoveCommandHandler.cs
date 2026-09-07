using MediatR;
using SaveMoney.Application.Users.Commands;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;

namespace SaveMoney.Application.Users.Handlers
{
    public class UserRemoveCommandHandler : IRequestHandler<UserRemoveCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UserRemoveCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UserRemoveCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new ApplicationException("Error could not be found.");
            return await _userRepository.DeleteAsync(user);
        }
    }
}
