using System.Text.Json.Serialization;

namespace AiModel.Domain.DTO;

public class PricingDto
{
    [JsonPropertyName("prompt")] public required double Prompt { get; set; }

    [JsonPropertyName("completion")] public required double Completion { get; set; }
}