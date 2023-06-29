using FluentValidation.Results;

namespace Newsletter.Application.Exceptions;

public class ValidatorException : Exception
{
    public ValidatorException(IEnumerable<ValidationFailure> failures)
        : base("One or more validation failures has ocurred.")
    {
        Errors = failures
            .Distinct()
            .Select(failure => new Dictionary<string, string>() { { failure.PropertyName, failure.ErrorMessage } })
            .ToArray();
    }

    public IReadOnlyDictionary<string, string>[] Errors { get; }
}
