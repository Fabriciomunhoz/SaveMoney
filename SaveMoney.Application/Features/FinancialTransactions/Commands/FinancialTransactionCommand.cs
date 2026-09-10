using MediatR;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Enums;

namespace SaveMoney.Application.Features.FinancialTransactions.Commands
{
    public abstract class FinancialTransactionCommand : IRequest<FinancialTransaction>
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; }
        public int IdUser { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationInMonths { get; set; }
    }
}
