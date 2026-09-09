using SaveMoney.Domain.Entities;

namespace SaveMoney.Domain.Interfaces
{
    public interface IFinancialTransactionRepository
    {
        Task<IEnumerable<FinancialTransaction>> GetFinancialTransactionsAsync();
        Task<FinancialTransaction> GetByIdAsync(int? id);
        Task<IEnumerable<FinancialTransaction>> GetFinancialTransactionUserAsync(int? id);
        Task<FinancialTransaction> CreateAsync(FinancialTransaction financialTransaction);
        Task<FinancialTransaction> UpdateAsync(FinancialTransaction financialTransaction);
        Task<FinancialTransaction> DeleteAsync(FinancialTransaction financialTransaction);
    }
}
