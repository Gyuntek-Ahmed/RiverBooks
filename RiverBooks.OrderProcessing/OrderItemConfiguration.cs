﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.OrderProcessing
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder
                .Property(x => x.Id)
                .ValueGeneratedNever();
            builder
                .Property(x => x.Description)
                .HasMaxLength(Constants.DESCRIPTION_MAXLENGTH)
                .IsRequired();
        }
    }
}
