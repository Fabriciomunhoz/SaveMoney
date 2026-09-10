using MediatR;
using SaveMoney.Application.Features.Roles.Commands;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;

namespace SaveMoney.Application.Features.Roles.Handlers
{
    public class RoleCreateCommandHandler : IRequestHandler<RoleCreateCommand, Role>
    {
        private readonly IRoleRepository _roleRepository;

        public RoleCreateCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> Handle(RoleCreateCommand request, CancellationToken cancellationToken)
        {
            var role = new Role(request.Name);
            if (role == null)
                throw new ApplicationException($"Error creating entity.");
            var result = await _roleRepository.CreateAsync(role);
            return result;
        }
    }
}
