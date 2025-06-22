using CodeCoop.Application.DTOs;
using CodeCoop.Application.Interfaces;
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

        app.MapPost("/api/trails", CreateTrail)
            .WithName("CreateTrail")
            .Accepts<TrailDto>("application/json")
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);
    }

    private static async Task<IResult> GetAllTrails([FromServices] IGetAllTrailsUseCase useCase)
    {
        var result = await useCase.ExecuteAsync();
        return Results.Ok(result);
    }

    private static async Task<IResult> CreateTrail(
        [FromBody] TrailDto dto,
        [FromServices] ICreateTrailUseCase useCase)
    {
        try
        {
            await useCase.ExecuteAsync(dto);
            return Results.Created($"/api/trails/{dto.Name}", dto);
        }
        catch (Exception ex)
        {
            // Logar o erro se desejar
            return Results.Problem($"Erro ao criar trilha: {ex.Message}");
        }
    }
}