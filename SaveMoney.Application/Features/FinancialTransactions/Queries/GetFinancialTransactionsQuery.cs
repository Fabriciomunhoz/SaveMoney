using MediatR;
using SaveMoney.Domain.Entities;

namespace SaveMoney.Application.Features.FinancialTransactions.Queries
{
    public class GetFinancialTransactionsQuery : IRequest<IEnumerable<FinancialTransaction>>
    {
    }
}
