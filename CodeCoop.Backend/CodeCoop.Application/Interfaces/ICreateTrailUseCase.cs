using CodeCoop.Application.DTOs;

namespace CodeCoop.Application.Interfaces;


public interface ICreateTrailUseCase
{
    Task ExecuteAsync(TrailDto dto);
}