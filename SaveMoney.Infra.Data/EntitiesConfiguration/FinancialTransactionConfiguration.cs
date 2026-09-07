using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveMoney.Domain.Entities;

namespace SaveMoney.Infra.Data.EntitiesConfiguration
{
    public class FinancialTransactionConfiguration : IEntityTypeConfiguration<FinancialTransaction>
    {
        public void Configure(EntityTypeBuilder<FinancialTransaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Amount).HasPrecision(10,2);
            builder.Property(x => x.Type).HasConversion<string>().HasMaxLength(30).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.FinancialTransactions).HasForeignKey(x => x.IdUser);
        }
    }
}
