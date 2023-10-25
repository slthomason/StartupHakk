using MediatR;
using VerticalSlicedMinimalApi.Application.Company.GetCompanyById;

namespace VerticalSlicedMinimalApi.API.Endpoints;

internal static class CompanyEndpointsGroup
{
    public static RouteGroupBuilder CompanyEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/companies/{id:guid}", HandleGetCompanyById);
        group.MapGet("/companies", () => "Get all companies endpoint.");
        return group;
    }

    private static async Task HandleGetCompanyById(
        HttpContext context, 
        IMediator mediator,
        Guid id)
    {
        var company = await mediator.Send(new GetCompanyByIdQuery { Id = id });
        await context.Response.WriteAsJsonAsync(company);
    }
}
