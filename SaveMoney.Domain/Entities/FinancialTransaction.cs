using SaveMoney.Domain.Enums;
using SaveMoney.Domain.Validation;

namespace SaveMoney.Domain.Entities
{
    public sealed class FinancialTransaction : Entity
    {
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public TransactionType Type { get; private set; }
        public int IdUser { get; set; }
        public User User { get; set; }

        public FinancialTransaction(decimal amount, string description, TransactionType type)
        {
            ValidateDomain(amount, description, type);
        }

        public FinancialTransaction(int id, decimal amount, string description, TransactionType type)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id.");
            Id = id;
            ValidateDomain(amount, description, type);
        }

        public void Update(decimal amount, string description, TransactionType type, int idUser)
        {
            ValidateDomain(amount, description, type);
            IdUser = idUser;
        }

        private void ValidateDomain(decimal amount, string description, TransactionType type)
        {
            DomainExceptionValidation.When(amount <= 0m,
                "Amount must be greater than zero.");

            DomainExceptionValidation.When(description.Length > 100,
                "Description too long. Max characters is 100.");

            DomainExceptionValidation.When(!Enum.IsDefined(type),
                "Invalid transaction type.");


            Amount = amount;
            Description = description;
            Type = type;
        }
    }
}
