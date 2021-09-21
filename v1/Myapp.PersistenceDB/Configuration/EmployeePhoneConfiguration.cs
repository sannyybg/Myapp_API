using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myapp.PersistenceDB.Configuration
{
    public class EmployeePhoneConfiguration: IEntityTypeConfiguration<EmployeePhone>
    {
        public void Configure(EntityTypeBuilder<EmployeePhone> builder)
        {
            builder.ToTable(nameof(EmployeePhone));

            builder.HasKey(xx => new { xx.EmployeeId, xx.PhoneId });

            builder.HasOne<Employees>(x => x.Employee)
                   .WithMany(s => s.EmployeePhones).OnDelete(DeleteBehavior.Cascade)
                   .HasForeignKey(s => s.EmployeeId);

            builder.HasOne<Phone>(x => x.Phone)
                   .WithMany(s => s.EmployeePhones)
                   .HasForeignKey(s => s.PhoneId);
        }
    }
}
