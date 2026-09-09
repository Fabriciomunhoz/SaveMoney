namespace SaveMoney.Application.Features.FinancialTransactions.Commands
{
    public class FinancialTransactionUpdateCommand : FinancialTransactionCommand
    {
        public int Id { get; set; }
        public FinancialTransactionUpdateCommand(int id)
        {
            Id = id;
        }
    }
}
