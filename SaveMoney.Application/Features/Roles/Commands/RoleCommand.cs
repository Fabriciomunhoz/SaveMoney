using MediatR;
using SaveMoney.Domain.Entities;

namespace SaveMoney.Application.Features.Roles.Commands
{
    public abstract class RoleCommand : IRequest<Role>
    {
        public string Name { get; set; }
    }
}
