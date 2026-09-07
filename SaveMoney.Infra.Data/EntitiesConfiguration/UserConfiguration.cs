using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveMoney.Domain.Entities;

namespace SaveMoney.Infra.Data.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Cpf).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.IdRole).IsRequired();

            builder.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.IdRole);

        }
    }
}
