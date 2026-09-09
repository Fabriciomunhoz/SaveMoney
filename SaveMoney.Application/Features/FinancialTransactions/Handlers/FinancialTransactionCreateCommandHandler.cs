using MediatR;
using SaveMoney.Application.Features.FinancialTransactions.Commands;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;

namespace SaveMoney.Application.Features.FinancialTransactions.Handlers
{
    public class FinancialTransactionCreateCommandHandler : IRequestHandler<FinancialTransactionCreateCommand, FinancialTransaction>
    {
        private readonly IFinancialTransactionRepository _financialTransactionRepository;

        public FinancialTransactionCreateCommandHandler(IFinancialTransactionRepository financialTransactionRepository)
        {
            _financialTransactionRepository = financialTransactionRepository;
        }

        public async Task<FinancialTransaction> Handle(FinancialTransactionCreateCommand request, CancellationToken cancellationToken)
        {
            var financialTransaction = new FinancialTransaction(request.Amount, request.Description, request.Type);
            if (financialTransaction == null)
                throw new ApplicationException("Financial transaction is null.");
            financialTransaction.IdUser = request.IdUser;

            return await _financialTransactionRepository.CreateAsync(financialTransaction);
        }
    }
}
