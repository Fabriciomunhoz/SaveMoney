using SaveMoney.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SaveMoney.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The email is required.")]
        [EmailAddress(ErrorMessage = "The email is not valid.")]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The age is required.")]
        [Range(0, 150, ErrorMessage = "The age must be between 0 and 150.")]
        [DisplayName("Age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "The CPF is required.")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "The password is required.")]
        [DisplayName("Password")]
        public string Password { get; set; }
        public int IdRole { get; set; }
        public Role Role { get; set; }
        public ICollection<FinancialTransaction> FinancialTransactions { get; set; }
    }
}
