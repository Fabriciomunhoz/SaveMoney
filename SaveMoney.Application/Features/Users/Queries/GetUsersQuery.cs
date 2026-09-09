using MediatR;
using SaveMoney.Domain.Entities;

namespace SaveMoney.Application.Features.Users.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}
