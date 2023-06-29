using MediatR;

namespace Newsletter.Application.Commands.Newsletter.CreateSubscriber;

public record CreateSubscriberCommand(string email, string firstName, string lastName) : IRequest<object>;

public record CreateSubscriberRequest(string email, string fristName, string lastName);
