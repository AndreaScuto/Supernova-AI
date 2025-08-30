using System.Text.Json.Serialization;


namespace Domain.Dto;

public class ChatDto
{
    [JsonPropertyName("id")] public required string Id { get; set; }
    [JsonPropertyName("choices")] public required List<ChoiceDto> Choices { get; set; }
}