using MediatR;
using SaveMoney.Domain.Entities;

namespace SaveMoney.Application.Users.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}
