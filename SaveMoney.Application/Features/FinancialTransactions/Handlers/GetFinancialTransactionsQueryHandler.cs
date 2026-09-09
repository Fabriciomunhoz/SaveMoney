using MediatR;
using SaveMoney.Application.Features.FinancialTransactions.Queries;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;

namespace SaveMoney.Application.Features.FinancialTransactions.Handlers
{
    public class GetFinancialTransactionsQueryHandler : IRequestHandler<GetFinancialTransactionsQuery, IEnumerable<FinancialTransaction>>
    {
        private readonly IFinancialTransactionRepository _financialTransactionRepository;

        public GetFinancialTransactionsQueryHandler(IFinancialTransactionRepository financialTransactionRepository)
        {
            _financialTransactionRepository = financialTransactionRepository;
        }

        public Task<IEnumerable<FinancialTransaction>> Handle(GetFinancialTransactionsQuery request, CancellationToken cancellationToken)
        {
            return _financialTransactionRepository.GetFinancialTransactionsAsync();
        }
    }
}
