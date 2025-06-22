using CodeCoop.Application.DTOs;
using CodeCoop.Application.Interfaces;

namespace CodeCoop.Application.UseCases;

public class GetAllTrailsUseCase : IGetAllTrailsUseCase
{
    private readonly ITrailRepository _trailRepository;

    public GetAllTrailsUseCase(ITrailRepository trailRepository)
    {
        _trailRepository = trailRepository;
    }

    public async Task<List<TrailDto>> ExecuteAsync()
    {
        return await _trailRepository.GetAllAsync();
    }
}