using Distillery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Distillery.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<CreditCard> CreditCards { get; }

    DbSet<CardBalance> CardBalances { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
