using MediatR;
using SaveMoney.Domain.Entities;

namespace SaveMoney.Application.Features.Roles.Queries
{
    public class GetRoleByIdQuery : IRequest<Role>
    {
        public int Id { get; set; }
        public GetRoleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
