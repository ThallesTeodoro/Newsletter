using Carter;

namespace Newsletter.Api.Newsletter;

public class NewsletterModule : CarterModule
{
    public NewsletterModule()
        : base("/newsletter")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => "Teste");
    }
}
