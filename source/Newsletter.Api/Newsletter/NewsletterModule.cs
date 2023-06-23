// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

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
