using SaveMoney.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
