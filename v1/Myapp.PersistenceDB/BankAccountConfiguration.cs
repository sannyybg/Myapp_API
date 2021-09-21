using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myapp.PersistenceDB
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.ToTable(nameof(BankAccount));

            builder.HasIndex(x => new { x.Iban }).IsUnique();

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Iban).IsUnicode(false).IsRequired().HasMaxLength(22).IsFixedLength();
            builder.Property(x => x.CCY).IsUnicode(false).IsRequired().HasMaxLength(3).IsFixedLength();
            builder.Property(x => x.Amount).IsRequired();

            builder.HasOne(x => x.Employee)
                   .WithMany(x => x.Accounts)
                   .IsRequired();

        }
    }
}
