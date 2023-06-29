using MediatR;
using Newsletter.Domain.Contracts.Persistence;
using Newsletter.Domain.Entities;
using Newsletter.Domain.Primitives.Types;

namespace Newsletter.Application.Commands.Newsletter.CreateSubscriber;

public class CreateSubscriberHandler : IRequestHandler<CreateSubscriberCommand, object>
{
    private readonly ISubscriberRepository _subscriberRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSubscriberHandler(ISubscriberRepository subscriberRepository, IUnitOfWork unitOfWork)
    {
        _subscriberRepository = subscriberRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<object> Handle(CreateSubscriberCommand request, CancellationToken cancellationToken)
    {
        var subscriber = new Subscriber(
            new SubscriberId(Guid.NewGuid()),
            request.email,
            request.firstName,
            request.lastName
        );

        await _subscriberRepository.AddAsync(subscriber);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new object {};
    }
}
