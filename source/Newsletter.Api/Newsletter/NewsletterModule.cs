using System.Net;
using Carter;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newsletter.Api.Contracts;
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
        app.MapPost("/", async (
            CreateSubscriberRequest request,
            IValidator<CreateSubscriberCommand> validator,
            ISender sender,
            HttpContext httpContext) =>
        {
            var response = new JsonResponse<object, object>(StatusCodes.Status201Created, null, null);

            await sender.Send(new CreateSubscriberCommand(
                request.email,
                request.fristName,
                request.lastName));

            httpContext.Response.StatusCode = response.StatusCode;

            return response.ToString();
        });
    }
}
