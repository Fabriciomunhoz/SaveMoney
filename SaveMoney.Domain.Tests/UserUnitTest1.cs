using FluentAssertions;
using SaveMoney.Domain.Entities;

namespace SaveMoney.Domain.Tests
{
    public class UserUnitTest1
    {
        [Fact(DisplayName ="Create User With Valid State")]
        public void CreateUser_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new User(1, "Fabricio", "fabriciombadeluk@gmail.com", 21, "13668289921", "fa27102004");
            action.Should()
                .NotThrow<SaveMoney.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateUser_NegativeIdValue_DomainExceptionIvalidId()
        {
            Action action = () => new User(-1, "Fabricio", "fabriciombadeluk@gmail.com", 21, "13668289921", "fa27102004");
            action.Should()
                .Throw<SaveMoney.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id.");
        }

        [Fact]
        public void CreateUser_EmailInvalid_DomainExceptionInvalidEmail()
        {
            Action action = () => new User(1, "Fabricio", "fabriciombadeluk#!gmail.com", 21, "13668289921", "fa27102004");
            action.Should()
                .Throw<SaveMoney.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid email. Verify.");
        }

        [Fact]
        public void CreateUser_ValidEmail_ResultObjectValidState()
        {
            Action action = () => new User(1, "Fabricio", "fabriciombadeluk@gmail.com", 21, "13668289921", "fa27102004");
            action.Should()
                .NotThrow<SaveMoney.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateUser_Minor_DomainExceptionMinorAge()
        {
            Action action = () => new User(1, "Fabricio", "fabriciombadeluk@gmail.com", 15, "13668289921", "fa27102004");
            action.Should()
                .Throw<SaveMoney.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Need be more 18 years old.");
        }

        [Fact]
        public void CreateUser_LegalAge_ResultObjectValidState()
        {
            Action action = () => new User(1, "Fabricio", "fabriciombadeluk@gmail.com", 18, "13668289921", "fa27102004");
            action.Should()
                .NotThrow<SaveMoney.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateUser_InvalidCpf_DomainExceptionInvalidCpf()
        {
            Action action = () => new User(1, "Fabricio", "fabriciombadeluk@gmail.com", 18, "13668289922", "fa27102004");
            action.Should()
                .Throw<SaveMoney.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid cpf.");
        }

        [Fact]
        public void CreateUser_ValidCpf_ResultObjectValidState()
        {
            Action action = () => new User(1, "Fabricio", "fabriciombadeluk@gmail.com", 18, "13668289921", "fa27102004");
            action.Should()
                .NotThrow<SaveMoney.Domain.Validation.DomainExceptionValidation>();
        }
    }
}