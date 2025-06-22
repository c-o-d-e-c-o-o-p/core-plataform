using CodeCoop.Application.DTOs;

namespace CodeCoop.Application.Interfaces;

public interface IGetAllTrailsUseCase
{
    Task<List<TrailDto>> ExecuteAsync();
}