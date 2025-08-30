using System.Text.Json.Serialization;

namespace AiModel.Domain.DTO;

public class OpenRouterResponseDto
{
    [JsonPropertyName("data")] public List<OpenRouterModelDto>? Data { get; set; }
}