using MediatR;
using SaveMoney.Application.Features.FinancialTransactions.Commands;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;

namespace SaveMoney.Application.Features.FinancialTransactions.Handlers
{
    public class FinancialTransactionRemoveCommandHandler : IRequestHandler<FinancialTransactionRemoveCommand, FinancialTransaction>
    {
        private readonly IFinancialTransactionRepository _financialTransactionRepository;

        public FinancialTransactionRemoveCommandHandler(IFinancialTransactionRepository financialTransactionRepository)
        {
            _financialTransactionRepository = financialTransactionRepository;
        }

        public async Task<FinancialTransaction> Handle(FinancialTransactionRemoveCommand request, CancellationToken cancellationToken)
        {
            var financialTransaction = await _financialTransactionRepository.GetByIdAsync(request.Id);
            if (financialTransaction == null)
                throw new ApplicationException("Financial transaction is null.");
            return await _financialTransactionRepository.DeleteAsync(financialTransaction);
        }
    }
}
