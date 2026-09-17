using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveMoney.Domain.Entities;
using SaveMoney.Infra.Data.Identity;

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
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.DurationInMonths).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();

            builder.HasOne<ApplicationUser>()
            .WithMany(x => x.FinancialTransactions)
            .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.ParentTransaction)
            .WithMany()
            .HasForeignKey(x => x.ParentTransactionId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
