using CodeCoop.Application.DTOs;
using CodeCoop.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace CodeCoop.Api.EndPoints;

public static class TrailEndpoint
{
    public static void ConfigureTrailEndpoints(this WebApplication app)
    {
        app.MapGet("/api/trails", GetAllTrails)
            .WithName("GetAllTrails")
            .Produces<List<TrailDto>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError);
    }

    private static async Task<IResult> GetAllTrails([FromServices] GetAllTrailsUseCase useCase)
    {
        var result = await useCase.ExecuteAsync();
        return Results.Ok(result);
    }
}