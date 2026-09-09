using MediatR;
using SaveMoney.Domain.Entities;

namespace SaveMoney.Application.Features.Users.Commands
{
    public abstract class UserCommand : IRequest<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
        public int IdRole { get; set; }
    }
}
