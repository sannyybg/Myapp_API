using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myapp.PersistenceDB.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.UserName }).IsUnique();//.HasFilter("\"IsDelete\" = false");
            builder.Property(x => x.UserName).IsUnicode(false).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Password).IsUnicode(false).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Email).IsUnicode(false).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
        }
    }
}
