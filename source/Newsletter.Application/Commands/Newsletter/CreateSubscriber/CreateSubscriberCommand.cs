using MediatR;

namespace Newsletter.Application.Commands.Newsletter.CreateSubscriber;

public record CreateSubscriberCommand(string email, string firstName, string lastName) : IRequest;
