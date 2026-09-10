using MediatR;
using SaveMoney.Application.Features.FinancialTransactions.Commands;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;

namespace SaveMoney.Application.Features.FinancialTransactions.Handlers
{
    public class FinancialTransactionUpdateCommandHandler : IRequestHandler<FinancialTransactionUpdateCommand, FinancialTransaction>
    {
        private readonly IFinancialTransactionRepository _financialTransactionRepository;

        public FinancialTransactionUpdateCommandHandler(IFinancialTransactionRepository financialTransactionRepository)
        {
            _financialTransactionRepository = financialTransactionRepository;
        }

        public async Task<FinancialTransaction> Handle(FinancialTransactionUpdateCommand request, CancellationToken cancellationToken)
        {
            var financialTransaction = await _financialTransactionRepository.GetByIdAsync(request.Id);
            if (financialTransaction == null)
                throw new ApplicationException("Financial transaction is null.");
            financialTransaction.Update(request.Amount, request.Description, request.Type, request.IdUser, request.StartDate, request.DurationInMonths);
            return await _financialTransactionRepository.UpdateAsync(financialTransaction);
        }
    }
}
