using SaveMoney.Domain.Enums;
using SaveMoney.Domain.Validation;

namespace SaveMoney.Domain.Entities
{
    public sealed class FinancialTransaction : Entity
    {
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public TransactionType Type { get; private set; }
        public DateTime StartDate { get; private set; }
        public int DurationInMonths { get; private set; }
        public DateTime EndDate { get; private set; }
        public int IdUser { get; set; }
        public User User { get; set; }

        public FinancialTransaction(decimal amount, string description, TransactionType type, DateTime startDate, int durationInMonths)
        {
            ValidateDomain(amount, description, type, startDate, durationInMonths);
        }

        public FinancialTransaction(int id, decimal amount, string description, TransactionType type, DateTime startDate, int durationInMonths)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id.");
            Id = id;
            ValidateDomain(amount, description, type, startDate, durationInMonths);
        }

        public void Update(decimal amount, string description, TransactionType type, int idUser, DateTime startDate, int durationInMonths)
        {
            ValidateDomain(amount, description, type, startDate, durationInMonths);
            IdUser = idUser;
        }

        private void ValidateDomain(decimal amount, string description, TransactionType type, DateTime startDate, int durationInMonths)
        {
            DomainExceptionValidation.When(amount <= 0m,
                "Amount must be greater than zero.");

            DomainExceptionValidation.When(description.Length > 100,
                "Description too long. Max characters is 100.");

            DomainExceptionValidation.When(!Enum.IsDefined(type),
                "Invalid transaction type.");

            DomainExceptionValidation.When(startDate == null,
                "Invalid is null.");

            DomainExceptionValidation.When(startDate == new DateTime(day: 1, month: 1, year: 1),
                "Invalid start Date.");

            DomainExceptionValidation.When(durationInMonths < 0,
                "Invalid duration in months. Min is zero.");


            Amount = amount;
            Description = description;
            Type = type;
            DurationInMonths = durationInMonths;
            StartDate = startDate;
            EndDate = StartDate.AddMonths(durationInMonths);
        }
    }
}
