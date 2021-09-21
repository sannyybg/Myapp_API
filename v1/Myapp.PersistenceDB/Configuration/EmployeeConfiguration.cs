using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myapp.PersistenceDB.Configuration
{
    class EmployeeConfiguration : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable(nameof(Employees));
            builder.Property(x => x.Email).IsUnicode(false).IsRequired().HasMaxLength(30).IsFixedLength();
            builder.Property(x => x.CardNumber).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);

            builder.HasMany(x => x.Accounts)
                    .WithOne(x => x.Employee)
                    .IsRequired();

        }
    }
}
