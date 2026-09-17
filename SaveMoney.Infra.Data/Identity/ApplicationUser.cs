using Microsoft.AspNetCore.Identity;
using SaveMoney.Domain.Entities;

namespace SaveMoney.Infra.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<FinancialTransaction> FinancialTransactions { get; set; }
    }
}
