using System.Text.Json.Serialization;

namespace AiModel.Domain.DTO;

public class PricingDto
{
    [JsonPropertyName("prompt")] public required string Prompt { get; set; }

    [JsonPropertyName("completion")] public required string Completion { get; set; }
}