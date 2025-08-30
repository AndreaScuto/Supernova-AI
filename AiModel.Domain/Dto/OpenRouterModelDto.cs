using System.Text.Json.Serialization;

namespace AiModel.Domain.DTO;

public class OpenRouterModelDto
{
    [JsonPropertyName("id")] public required string Id { get; set; }

    [JsonPropertyName("description")] public required string Description { get; set; }

    [JsonPropertyName("release")] public required long ReleaseDate { get; set; }

    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("context_length")] public required long ContextLength { get; set; }

    [JsonPropertyName("pricing")] public required PricingDto Pricing { get; set; }
}