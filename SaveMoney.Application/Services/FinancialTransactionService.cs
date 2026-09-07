using AutoMapper;
using SaveMoney.Application.DTOs;
using SaveMoney.Application.Interfaces;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;

namespace SaveMoney.Application.Services
{
    public class FinancialTransactionService : IFinancialTransactionService
    {
        private readonly IFinancialTransactionRepository _financialTransactionRepository;
        private readonly IMapper _mapper;

        public FinancialTransactionService(IFinancialTransactionRepository financialTransactionRepository, IMapper mapper)
        {
            _financialTransactionRepository = financialTransactionRepository ??
                throw new ArgumentNullException(nameof(financialTransactionRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<FinancialTransactionDTO>> GetFinancialTransactions()
        {
            var financialTransactionsEntity = await _financialTransactionRepository.GetFinancialTransactionsAsync();
            return _mapper.Map<IEnumerable<FinancialTransactionDTO>>(financialTransactionsEntity);
        }

        public async Task<FinancialTransactionDTO> GetById(int? id)
        {
            var financialTransactionEntity = await _financialTransactionRepository.GetByIdAsync(id);
            return _mapper.Map<FinancialTransactionDTO>(financialTransactionEntity);
        }

        public async Task Add(FinancialTransactionDTO financialTransactionDTO)
        {
            var financialTransactionEntity = _mapper.Map<FinancialTransaction>(financialTransactionDTO);
            await _financialTransactionRepository.CreateAsync(financialTransactionEntity);
        }

        public async Task Update(FinancialTransactionDTO financialTransactionDTO)
        {
            var financialTransactionEntity = _mapper.Map<FinancialTransaction>(financialTransactionDTO);
            await _financialTransactionRepository.UpdateAsync(financialTransactionEntity);
        }

        public async Task Remove(int? id)
        {
            var financialTransactionEntity = await _financialTransactionRepository.GetByIdAsync(id);
            await _financialTransactionRepository.DeleteAsync(financialTransactionEntity);
        }
    }
}
