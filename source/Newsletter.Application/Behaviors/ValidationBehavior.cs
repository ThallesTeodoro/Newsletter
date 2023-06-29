using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Newsletter.Application.Exceptions;

namespace Newsletter.Application.Behaviors;

internal sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
    where TResponse : class
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var failures = new List<ValidationFailure>();

        foreach (var validator in _validators)
        {
            var validatorResult = await validator.ValidateAsync(context);

            if (!validatorResult.IsValid)
            {
                failures.AddRange(validatorResult.Errors);
            }
        }

        if (failures.Count != 0)
        {
            throw new ValidatorException(failures);
        }

        return await next();
    }
}
