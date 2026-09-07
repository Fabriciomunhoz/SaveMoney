using SaveMoney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMoney.Domain.Interfaces
{
    public interface IFinancialTransactionRepository
    {
        Task<IEnumerable<FinancialTransaction>> GetFinancialTransactionsAsync();
        Task<FinancialTransaction> GetByIdAsync(int? id);
        Task<FinancialTransaction> GetFinancialTransactionUserAsync(int? id);
        Task<FinancialTransaction> CreateAsync(FinancialTransaction user);
        Task<FinancialTransaction> UpdateAsync(FinancialTransaction user);
        Task<FinancialTransaction> DeleteAsync(FinancialTransaction user);
    }
}
