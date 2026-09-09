namespace SaveMoney.Application.Features.FinancialTransactions.Commands
{
    public class FinancialTransactionRemoveCommand : FinancialTransactionCommand
    {
        public int Id { get; set; }
        public FinancialTransactionRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
