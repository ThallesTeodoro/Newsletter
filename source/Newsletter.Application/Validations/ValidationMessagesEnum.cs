namespace Newsletter.Application.Validations;

public static class ValidationMessagesEnum
{
    public const string SubscriberEmailIsNotUnique = "The email must be unique.";
    public const string SubscriberEmailIsNull = "The email must be present.";
    public const string SubscriberFirstNameIsNull = "The first name must be present.";
    public const string SubscriberLastNameIsNull = "The last name must be present.";
}
