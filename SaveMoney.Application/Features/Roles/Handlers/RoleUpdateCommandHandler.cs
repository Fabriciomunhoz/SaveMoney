using MediatR;
using SaveMoney.Application.Features.Roles.Commands;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;

namespace SaveMoney.Application.Features.Roles.Handlers
{
    internal class RoleUpdateCommandHandler : IRequestHandler<RoleUpdateCommand, Role>
    {
        private readonly IRoleRepository _roleRepository;

        public RoleUpdateCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> Handle(RoleUpdateCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByIdAsync(request.Id);
            if (role == null)
                throw new ArgumentException("Role not find.");
            role.Update(request.Name);
            return role;
        }
    }
}
