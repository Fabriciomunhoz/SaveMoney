using MediatR;
using SaveMoney.Application.Users.Commands;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMoney.Application.Users.Handlers
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UserCreateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email, request.Age, request.Cpf, request.Password);
            if (user == null)
                throw new ApplicationException($"Error creating entity.");

            user.IdRole = request.IdRole;
            return await _userRepository.CreateAsync(user);
        }
    }
}
