using CodeCoop.Application.DTOs;
using CodeCoop.Application.Interfaces;

namespace CodeCoop.Application.UseCases;


public class CreateTrailUseCase : ICreateTrailUseCase
{
    private readonly ITrailRepository _repository;

    public CreateTrailUseCase(ITrailRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(TrailDto dto)
    {
        // Aqui você pode aplicar validações de negócio antes de criar
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ArgumentException("O nome da trilha não pode estar vazio.");

        await _repository.CreateAsync(dto);
    }
}