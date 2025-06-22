using System.Text.Json;
using CodeCoop.Application.DTOs;
using CodeCoop.Infrastructure.Notion.Extensions;

namespace CodeCoop.Infrastructure.Notion.Mappers;

public static class TrailMapper
{
    public static TrailDto ToTrailDto(this JsonElement item)
    {
        var props = item.GetProperty("properties");

        return new TrailDto
        {
            Name = props.GetTitle("Name"),
            Level = props.GetSelect("Level"),
            Status = props.GetSelect("Status"),
            GitHubRepo = props.GetUrl("GitHubRepo"),
            DiscordChannel = props.GetRichText("DiscordChannel")
        };
    }
}