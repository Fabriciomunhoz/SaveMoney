using MediatR;
using SaveMoney.Application.Features.Roles.Queries;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;

namespace SaveMoney.Application.Features.Roles.Handlers
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, IEnumerable<Role>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRolesQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Role>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            return await _roleRepository.GetRolesAsync();
        }
    }
}
