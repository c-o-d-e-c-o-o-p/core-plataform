using System.Text.Json;

namespace CodeCoop.Infrastructure.Notion.Extensions;

public static class JsonElementExtensions
{
    public static string GetTitle(this JsonElement props, string field)
    {
        if (props.TryGetProperty(field, out var prop) &&
            prop.TryGetProperty("title", out var titleArray) &&
            titleArray.ValueKind == JsonValueKind.Array &&
            titleArray.GetArrayLength() > 0)
        {
            return titleArray[0].GetProperty("text").GetProperty("content").GetString() ?? "";
        }
        return "";
    }

    public static string GetSelect(this JsonElement props, string field)
    {
        if (props.TryGetProperty(field, out var prop) &&
            prop.TryGetProperty("select", out var select) &&
            select.ValueKind == JsonValueKind.Object &&
            select.TryGetProperty("name", out var name))
        {
            return name.GetString() ?? "";
        }
        return "";
    }

    public static string GetUrl(this JsonElement props, string field)
    {
        if (props.TryGetProperty(field, out var prop) &&
            prop.TryGetProperty("url", out var url))
        {
            return url.GetString() ?? "";
        }
        return "";
    }

    public static string GetRichText(this JsonElement props, string field)
    {
        if (props.TryGetProperty(field, out var prop) &&
            prop.TryGetProperty("rich_text", out var textArray) &&
            textArray.ValueKind == JsonValueKind.Array &&
            textArray.GetArrayLength() > 0)
        {
            return textArray[0].GetProperty("text").GetProperty("content").GetString() ?? "";
        }
        return "";
    }
}