using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMoney.Application.DTOs
{
    public class FinancialTransactionDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The amount is required.")]
        [DisplayName("Amount")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "The description is required.")]
        [MaxLength(200, ErrorMessage = "The description cannot exceed 200 characters.")]
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Type")]
        public TransactionType Type { get; set; }
        [DisplayName("IdUser")]
        public int IdUser { get; set; }
        [DisplayName("User")]
        public User User { get; set; }
    }
}
