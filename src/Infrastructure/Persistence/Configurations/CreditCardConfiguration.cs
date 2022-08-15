using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distillery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Distillery.Infrastructure.Persistence.Configurations;
public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder.Property(t => t.CardNumber)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(t => t.TotalCredit)
            .IsRequired();

        builder.Property(t => t.CurrentCredit)
            .IsRequired();

        builder.Property(t => t.CardOwner)
            .IsRequired();

        builder.HasIndex(t => t.CardNumber)
            .IsUnique(true);

    }
}
