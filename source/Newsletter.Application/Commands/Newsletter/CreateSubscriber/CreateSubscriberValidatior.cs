using FluentValidation;
using Newsletter.Application.Validations;
using Newsletter.Domain.Contracts.Persistence;

namespace Newsletter.Application.Commands.Newsletter.CreateSubscriber;

public sealed class CreateSubscriberValidatior : AbstractValidator<CreateSubscriberCommand>
{
    public CreateSubscriberValidatior(ISubscriberRepository subscriberRepository)
    {
        RuleFor(c => c.firstName)
            .NotNull()
            .WithMessage(ValidationMessagesEnum.SubscriberFirstNameIsNull);

        RuleFor(c => c.lastName)
            .NotNull()
            .WithMessage(ValidationMessagesEnum.SubscriberLastNameIsNull);

        RuleFor(c => c.email)
            .NotNull()
            .WithMessage(ValidationMessagesEnum.SubscriberEmailIsNull)
            .MustAsync(async (email, _) => await subscriberRepository.EmailIsUniqueAsync(email))
            .WithMessage(ValidationMessagesEnum.SubscriberEmailIsNotUnique);
    }
}
