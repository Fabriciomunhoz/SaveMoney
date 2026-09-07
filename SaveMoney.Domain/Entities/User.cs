using SaveMoney.Domain.Validation;
using System.Net.Mail;


namespace SaveMoney.Domain.Entities
{
    public sealed class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }
        public string Cpf { get; private set; }
        public string Password { get; private set; }
        public int IdRole { get; set; }
        public Role Role { get; set; }
        public ICollection<FinancialTransaction> FinancialTransactions { get; set; }

        public User(string name, string email, int age, string cpf, string password)
        {
            ValidateDomain(name, email, age, cpf, password);
        }
        public User(int id, string name, string email, int age, string cpf, string password)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id.");
            Id = id;
            ValidateDomain(name, email, age, cpf, password);
        }

        public void Update(string name, string email, int age, string cpf, string password, int idRole)
        {
            ValidateDomain(name, email, age, cpf, password);
            IdRole = idRole;
        }

        private void ValidateDomain(string name, string email, int age, string cpf, string password)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), 
                "Invalid name. Name is requered");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name. Too short, minimum 3 characters");

            DomainExceptionValidation.When(IsValidEmail(email),
                "Invalid email. Verify.");

            DomainExceptionValidation.When(age < 18,
                "Need be more 18 years old.");

            DomainExceptionValidation.When(!CpfValido(cpf),
                "Invalid cpf.");

            DomainExceptionValidation.When(password.Length < 8,
                "Password need be more 8 length.");

            Name = name;
            Email = email;
            Age = age;
            Cpf = cpf;
            Password = password;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return false;
            }
            catch (FormatException)
            {
                return true;
            }
        }

        private static bool CpfValido(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = cpf.Replace(".", "").Replace("-", "").Trim();

            if (cpf.Length != 11 || !cpf.All(char.IsDigit))
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            if (digito1 != cpf[9] - '0')
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return digito2 == cpf[10] - '0';
        }
    }
}
