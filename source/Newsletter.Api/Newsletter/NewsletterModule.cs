using Carter;
using MediatR;
using Newsletter.Application.Commands.Newsletter.CreateSubscriber;

namespace Newsletter.Api.Newsletter;

public class NewsletterModule : CarterModule
{
    public NewsletterModule()
        : base("/newsletter")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/", async (CreateSubscriberCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        });
    }
}
