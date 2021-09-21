using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myapp.PersistenceDB.Configuration
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable(nameof(Phone));
            builder.HasIndex(x => new { x.Number }).IsUnique();
            builder.Property(x => x.Number).IsUnicode(false).IsRequired().HasMaxLength(10).IsFixedLength();
            builder.Property(x => x.TypeId).IsRequired();
        }
    }
}
