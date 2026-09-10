using MediatR;
using SaveMoney.Application.Features.Roles.Commands;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;

namespace SaveMoney.Application.Features.Roles.Handlers
{
    public class RoleRemoveCommandHandler : IRequestHandler<RoleRemoveCommand, Role>
    {
        private readonly IRoleRepository _roleRepository;

        public RoleRemoveCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> Handle(RoleRemoveCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByIdAsync(request.Id);
            if (role == null)
                throw new ArgumentException("Role not find.");
            return await _roleRepository.DeleteAsync(role);
        }
    }
}
