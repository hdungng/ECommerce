using ECommerce.Application.Abstractions.Persistence;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories;

public sealed class CartRepository : ICartRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CartRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task UpsertAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        var existing = await _dbContext.Carts.FirstOrDefaultAsync(x => x.Id == cart.Id, cancellationToken);
        if (existing is null)
        {
            await _dbContext.Carts.AddAsync(cart, cancellationToken);
        }
    }

    public Task<Cart?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return _dbContext.Carts
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
    }
}
