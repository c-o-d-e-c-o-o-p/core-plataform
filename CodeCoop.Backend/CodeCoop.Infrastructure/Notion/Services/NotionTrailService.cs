using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using CodeCoop.Application.DTOs;
using CodeCoop.Application.Interfaces;
using CodeCoop.Infrastructure.Notion.Extensions;
using CodeCoop.Infrastructure.Notion.Mappers;
using Microsoft.Extensions.Configuration;

namespace CodeCoop.Infrastructure.Notion.Services;

public class NotionTrailService : ITrailRepository
{
    private readonly HttpClient _httpClient;
    private readonly string _databaseId;
    private readonly string _notionVersion = "2022-06-28";

    public NotionTrailService(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        var secret = configuration["Notion:Secret"];
        _databaseId = configuration["Notion:DatabaseId"];
        
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", secret);
        _httpClient.DefaultRequestHeaders.Add("Notion-Version", _notionVersion);
    }

    public async Task<List<TrailDto>> GetAllAsync()
    {
        var url = $"https://api.notion.com/v1/databases/{_databaseId}/query";

        var content = new StringContent("{}", Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        using var json = JsonDocument.Parse(responseContent);

        return json.RootElement
            .GetProperty("results")
            .EnumerateArray()
            .Select(item => item.ToTrailDto())
            .ToList();
    }

}