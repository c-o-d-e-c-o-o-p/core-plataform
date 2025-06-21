using CodeCoop.Application.DTOs;
using CodeCoop.Application.Interfaces;

namespace CodeCoop.Infrastructure.Notion.Services;

public class NotionTrailService : ITrailRepository
{
    public async Task<List<TrailDto>> GetAllAsync()
    {
        // Aqui você chama a API do Notion de verdade (mock temporário abaixo)
        await Task.Delay(100); // Simula delay de rede
        return new List<TrailDto>
        {
            new TrailDto { Name = ".NET Clean Architecture", Level = "Intermediário", Status = "Ativa" },
            new TrailDto { Name = "Python do Zero", Level = "Iniciante", Status = "Em criação" }
        };
    }
}