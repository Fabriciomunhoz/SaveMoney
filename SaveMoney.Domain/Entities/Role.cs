using SaveMoney.Domain.Validation;

namespace SaveMoney.Domain.Entities
{
    public sealed class Role : Entity
    {
        public string Name { get; private set; }
        public ICollection<User> Users { get; set; }

        public Role(string name)
        {
            CreatedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            ValidateDomain(name);
        }
        public Role(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id.");
            Id = id;
            CreatedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
                "Invalid name. Name is requered");
            Name = name;
        }
    }
}
