using System.Text.Json.Serialization;

namespace Domain.Dto;

public class ChoiceDto
{
    [JsonPropertyName("message")] public required MessageDto Message { get; set; }
}