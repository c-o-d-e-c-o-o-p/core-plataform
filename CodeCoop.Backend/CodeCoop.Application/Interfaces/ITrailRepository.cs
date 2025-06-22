using CodeCoop.Application.DTOs;

namespace CodeCoop.Application.Interfaces;

public interface ITrailRepository
{
    Task<List<TrailDto>> GetAllAsync();
    Task CreateAsync(TrailDto dto);
}