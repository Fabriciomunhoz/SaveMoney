using MediatR;
using SaveMoney.Domain.Entities;

namespace SaveMoney.Application.Users.Commands
{
    public class UserRemoveCommand : IRequest<User>
    {
        public int Id { get; set; }

        public UserRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
