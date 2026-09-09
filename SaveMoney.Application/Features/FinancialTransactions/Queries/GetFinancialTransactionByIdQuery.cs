using MediatR;
using SaveMoney.Domain.Entities;

namespace SaveMoney.Application.Features.FinancialTransactions.Queries
{
    public class GetFinancialTransactionByIdQuery : IRequest<FinancialTransaction>
    {
        public int Id { get; set; }
        public GetFinancialTransactionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
