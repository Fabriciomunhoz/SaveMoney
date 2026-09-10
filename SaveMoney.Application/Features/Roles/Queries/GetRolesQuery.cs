using MediatR;
using SaveMoney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMoney.Application.Features.Roles.Queries
{
    public class GetRolesQuery : IRequest<IEnumerable<Role>>
    {
    }
}
