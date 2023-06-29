using Microsoft.EntityFrameworkCore;
using Newsletter.Domain.Contracts.Persistence;
using Newsletter.Domain.Entities;

namespace Newsletter.Infrastructure.Persistence;

public class SubscriberRepository : ISubscriberRepository
{
    private readonly ApplicationDbContext _context;

    public SubscriberRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Subscriber subscriber)
    {
        await _context
            .Set<Subscriber>()
            .AddAsync(subscriber);
    }

    public async Task<bool> EmailIsUniqueAsync(string email)
    {
        return !await _context
            .Set<Subscriber>()
            .AnyAsync(s => s.Email == email);
    }
}
