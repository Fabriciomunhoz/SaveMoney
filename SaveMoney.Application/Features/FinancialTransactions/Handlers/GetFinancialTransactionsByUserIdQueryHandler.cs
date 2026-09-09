using MediatR;
using SaveMoney.Application.Features.FinancialTransactions.Queries;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;

namespace SaveMoney.Application.Features.FinancialTransactions.Handlers
{
    public class GetFinancialTransactionsByUserIdQueryHandler : IRequestHandler<GetFinancialTransactionByUserIdQuery, IEnumerable<FinancialTransaction>>
    {
        private readonly IFinancialTransactionRepository _financialTransactionRepository;

        public GetFinancialTransactionsByUserIdQueryHandler(IFinancialTransactionRepository financialTransactionRepository)
        {
            _financialTransactionRepository = financialTransactionRepository;
        }

        public async Task<IEnumerable<FinancialTransaction>> Handle(GetFinancialTransactionByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _financialTransactionRepository.GetFinancialTransactionUserAsync(request.IdUser);
        }
    }
}
