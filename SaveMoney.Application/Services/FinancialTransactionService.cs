using AutoMapper;
using MediatR;
using SaveMoney.Application.DTOs;
using SaveMoney.Application.Features.FinancialTransactions.Commands;
using SaveMoney.Application.Features.FinancialTransactions.Queries;
using SaveMoney.Application.Features.Users.Commands;
using SaveMoney.Application.Interfaces;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;

namespace SaveMoney.Application.Services
{
    public class FinancialTransactionService : IFinancialTransactionService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public FinancialTransactionService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FinancialTransactionDTO>> GetFinancialTransactions()
        {
            var financialQuery = new GetFinancialTransactionsQuery();
            if (financialQuery == null)
                throw new ArgumentNullException("Financial transaction is null.");

            var result = await _mediator.Send(financialQuery);
            return _mapper.Map<IEnumerable<FinancialTransactionDTO>>(result);
        }

        public async Task<FinancialTransactionDTO> GetById(int? id)
        {
            var financialIdQuery = new GetFinancialTransactionByIdQuery(id.Value);
            if (financialIdQuery == null)
                throw new ArgumentNullException("Financial transaction is null.");
            var result = await _mediator.Send(financialIdQuery);
            return _mapper.Map<FinancialTransactionDTO>(result);
        }

        public async Task Add(FinancialTransactionDTO financialTransactionDTO)
        {
            var financialTransactionEntity = _mapper.Map<FinancialTransactionCreateCommand>(financialTransactionDTO);
            await _mediator.Send(financialTransactionEntity);
        }

        public async Task Update(FinancialTransactionDTO financialTransactionDTO)
        {
            var financialTransactionEntity = _mapper.Map<FinancialTransactionUpdateCommand>(financialTransactionDTO);
            await _mediator.Send(financialTransactionEntity);
        }

        public async Task Remove(int? id)
        {
            var financialTransactionId = new FinancialTransactionRemoveCommand(id.Value);
            if (financialTransactionId == null)
                throw new ArgumentNullException("Financial transaction is null.");
            await _mediator.Send(financialTransactionId);
        }
    }
}
