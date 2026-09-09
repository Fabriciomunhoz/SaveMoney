using MediatR;
using SaveMoney.Application.Features.FinancialTransactions.Queries;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;

namespace SaveMoney.Application.Features.FinancialTransactions.Handlers
{
    public class GetFinancialTransactionByIdQueryHandler : IRequestHandler<GetFinancialTransactionByIdQuery, FinancialTransaction>
    {
        private readonly IFinancialTransactionRepository _financialTransactionRepository;

        public GetFinancialTransactionByIdQueryHandler(IFinancialTransactionRepository financialTransactionRepository)
        {
            _financialTransactionRepository = financialTransactionRepository;
        }

        public async Task<FinancialTransaction> Handle(GetFinancialTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _financialTransactionRepository.GetByIdAsync(request.Id);
        }
    }
}
