using FluentAssertions;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Enums;

namespace SaveMoney.Domain.Tests;

public class FinancialTransactionUnitTest1
{
    [Fact(DisplayName = "Create FinancialTransaction Valid")]
    public void CreateFinancialTransaction_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new FinancialTransaction(100, "Financiamento", TransactionType.Debit, new DateTime(day: 7, month: 6, year: 2026), 21);
        action.Should()
            .NotThrow<Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create FinancialTransaction with amount Invalid")]
    public void CreateFinancialTransaction_WithInvalidAmount_AmountInvalidException()
    {
        Action action = () => new FinancialTransaction(1, 0.00m, "Financiamento", TransactionType.Debit, new DateTime(day: 7, month: 6, year: 2026), 21);
        action.Should()
            .Throw<Validation.DomainExceptionValidation>()
            .WithMessage("Amount must be greater than zero.");
    }

    [Fact(DisplayName = "Create FinancialTransaction with valid amount")]
    public void CreateFinancialTransaction_WithValidAmount_ResultObjectValidState()
    {
        Action action = () => new FinancialTransaction(1, 0.01m, "Financiamento", TransactionType.Debit, new DateTime(day: 7, month: 6, year: 2026), 21);
        action.Should()
            .NotThrow<Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create FinancialTransaction with invalid type")]
    public void CreateFinancialTransaction_WithInvalidType_TypeInvalidEception()
    {
        Action action = () => new FinancialTransaction(1, 0.01m, "Financiamento", (TransactionType)999, new DateTime(day: 7, month: 6, year: 2026), 21);
        action.Should()
            .Throw<Validation.DomainExceptionValidation>()
            .WithMessage("Invalid transaction type.");
    }
}
