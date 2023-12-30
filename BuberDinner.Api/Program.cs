//using BuberDinner.Api.Filters;
//using BuberDinner.Api.Middleware;
using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    //app.Map("/error", (HttpContext httpContext) =>
    //{
    //    Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

    //    return Results.Problem(title: exception?.Message);
    //});
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
}

app.Run();
