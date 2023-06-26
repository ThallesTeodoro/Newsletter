using Newsletter.Domain.Types;

namespace Newsletter.Domain.Entities;

public class Subscriber
{
    public Subscriber(SubscriberId id, string email, string firstName, string lastName)
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    public SubscriberId Id { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}
