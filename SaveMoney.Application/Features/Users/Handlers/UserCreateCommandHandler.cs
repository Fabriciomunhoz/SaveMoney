using MediatR;
using SaveMoney.Application.Features.Users.Commands;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Enums;
using SaveMoney.Domain.Interfaces;

namespace SaveMoney.Application.Features.Users.Handlers
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFinancialTransactionRepository _financialTransactionRepository;

        public UserCreateCommandHandler(IUserRepository userRepository, IFinancialTransactionRepository financialTransactionRepository)
        {
            _userRepository = userRepository;
            _financialTransactionRepository = financialTransactionRepository;
        }

        public async Task<User> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email, request.Age, request.Cpf, request.Password);
            if (user == null)
                throw new ApplicationException($"Error creating entity.");

            user.IdRole = request.IdRole;
            var userCreated = await _userRepository.CreateAsync(user);
            var transactionCreated = await _financialTransactionRepository.CreateAsync(new FinancialTransaction(100.00m, "Teste", TransactionType.Credit, DateTime.Now, 5));
            userCreated.FinancialTransactions.Add(transactionCreated);
            return userCreated;
        }
    }
}
