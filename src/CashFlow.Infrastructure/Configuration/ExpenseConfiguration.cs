using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Infrastructure.Configuration;

internal class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("Expenses");
        builder.HasKey(col => col.Id);
        builder.Property(col => col.Title).IsRequired().HasMaxLength(200);
        builder.Property(col => col.Description).HasMaxLength(200);
        builder.Property(col => col.Date).IsRequired().HasColumnType("timestamp");
        builder.Property(col => col.Amount).IsRequired().HasColumnType("numeric(10,2)");
        builder.Property(col => col.PaymentType)
            .IsRequired()
            .HasConversion<string>()
            .HasColumnType("varchar(10)");
    }
}