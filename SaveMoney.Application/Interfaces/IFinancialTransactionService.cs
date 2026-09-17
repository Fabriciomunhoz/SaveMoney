using SaveMoney.Application.DTOs;

namespace SaveMoney.Application.Interfaces
{
    public interface IFinancialTransactionService
    {
        Task<IEnumerable<FinancialTransactionDTO>> GetFinancialTransactions();
        Task<FinancialTransactionDTO> GetById(int? id);
        
        Task Add(FinancialTransactionDTO financialTransactionDTO);
        Task Update(FinancialTransactionDTO financialTransactionDTO);
        Task Remove(int? id);
    }
}
