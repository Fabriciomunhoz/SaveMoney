using MediatR;
using SaveMoney.Application.Features.ApplicationUsers.Commands;
using SaveMoney.Application.Features.FinancialTransactions.Commands;
using SaveMoney.Application.Interfaces;
using SaveMoney.Domain.Enums;

namespace SaveMoney.Application.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IMediator _mediator;

        public ApplicationUserService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task RegisterUser(string email, string password)
        {
            try
            {
                var userId = await _mediator.Send(new ApplicationUserRegisterCommand
                {
                    Email = email,
                    Password = password
                });

                await _mediator.Send(new FinancialTransactionCreateCommand
                {
                    IdUser = userId,
                    Amount = 10,
                    Description = "Initial testing Debit",
                    Type = TransactionType.Debit,
                    StartDate = DateTime.Now,
                    DurationInMonths = 1
                });
                await _mediator.Send(new FinancialTransactionCreateCommand
                {
                    IdUser = userId,
                    Amount = 10,
                    Description = "Initial testing Payment",
                    Type = TransactionType.Credit,
                    StartDate = DateTime.Now,
                    DurationInMonths = 1
                });
            }
            catch
            {
                throw;
            }
        }
    }
}
