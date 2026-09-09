using MediatR;
using SaveMoney.Domain.Entities;

namespace SaveMoney.Application.Features.FinancialTransactions.Queries
{
    public class GetFinancialTransactionByUserIdQuery : IRequest<IEnumerable<FinancialTransaction>>
    {
        public int IdUser { get; set; }
        public GetFinancialTransactionByUserIdQuery(int idUser)
        {
            IdUser = idUser;
        }
    }
}
