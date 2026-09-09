using Microsoft.EntityFrameworkCore;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;
using SaveMoney.Infra.Data.Context;

namespace SaveMoney.Infra.Data.Repositories
{
    public class FinancialTransactionRepository : IFinancialTransactionRepository
    {
        private readonly ApplicationDbContext _ctx;

        public FinancialTransactionRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<FinancialTransaction>> GetFinancialTransactionsAsync()
        {
            return await _ctx.FinancialTransactions
                .ToListAsync();
        }

        public async Task<FinancialTransaction> GetByIdAsync(int? id)
        {
            return await _ctx.FinancialTransactions
                .Include(x => x.User)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<FinancialTransaction>> GetFinancialTransactionUserAsync(int? id)
        {
            return await _ctx.FinancialTransactions
                .Include(x => x.User)
                .Where(x => x.IdUser == id)
                .ToListAsync();
        }

        public async Task<FinancialTransaction> CreateAsync(FinancialTransaction financialTransaction)
        {
            _ctx.FinancialTransactions.Add(financialTransaction);
            await _ctx.SaveChangesAsync();
            return financialTransaction;
        }

        public async Task<FinancialTransaction> UpdateAsync(FinancialTransaction financialTransaction)
        {
            _ctx.FinancialTransactions.Update(financialTransaction);
            await _ctx.SaveChangesAsync();
            return financialTransaction;
        }

        public async Task<FinancialTransaction> DeleteAsync(FinancialTransaction financialTransaction)
        {
            _ctx.FinancialTransactions.Remove(financialTransaction);
            await _ctx.SaveChangesAsync();
            return financialTransaction;
        }
    }
}
