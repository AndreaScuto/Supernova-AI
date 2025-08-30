using System.Text.Json.Serialization;

namespace Domain.Dto;

public class MessageDto
{
    [JsonPropertyName("role")] public string Role { get; set; }
    [JsonPropertyName("Content")] public string Content { get; set; }
}