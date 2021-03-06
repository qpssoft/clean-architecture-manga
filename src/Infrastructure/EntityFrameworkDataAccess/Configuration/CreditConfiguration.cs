// <copyright file="CreditConfiguration.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.EntityFrameworkDataAccess.Configuration
{
    using Domain.Accounts.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Credit Configuration.
    /// </summary>
    public class CreditConfiguration : IEntityTypeConfiguration<Credit>
    {
        /// <summary>
        /// Configure Credit.
        /// </summary>
        /// <param name="builder">Builder.</param>
        public void Configure(EntityTypeBuilder<Credit> builder)
        {
            builder.ToTable("Credit");

            builder.Property(credit => credit.Amount)
                .HasConversion(
                    value => value.ToMoney().ToDecimal(),
                    value => new PositiveMoney(value))
                .IsRequired();

            builder.Property(credit => credit.Id)
                .HasConversion(
                    value => value.ToGuid(),
                    value => new Domain.Accounts.Credits.CreditId(value))
                .IsRequired();

            builder.Property(credit => credit.AccountId)
                .HasConversion(
                    value => value.ToGuid(),
                    value => new AccountId(value))
                .IsRequired();
        }
    }
}
