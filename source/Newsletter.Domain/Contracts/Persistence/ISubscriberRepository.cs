using Newsletter.Domain.Entities;

namespace Newsletter.Domain.Contracts.Persistence;

public interface ISubscriberRepository
{
    Task AddAsync(Subscriber subscriber);

    Task<bool> EmailIsUniqueAsync(string email);
}
