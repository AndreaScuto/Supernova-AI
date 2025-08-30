using AiModel.Domain.Models;
using System.Text.Json;
using AiModel.Domain.DTO;

namespace AiModel.Infrastructure;

public class OpenRouterClient(HttpClient client)
{
    public async Task<List<Ai>?> FetchOpenRouterModels()
    {
        var response = await client.GetAsync("https://openrouter.ai/api/v1/models");
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var aiDto = JsonSerializer.Deserialize<OpenRouterResponseDto>(jsonResponse);

        return aiDto?.Data?.Select(dto => new Ai
        {
            Id = dto.Id,
            Name = dto.Name,
            ReleaseDate = dto.ReleaseDate,
            Description = dto.Description,
            ContextLength = dto.ContextLength,
            Pricing = new Pricing
            {
                PriceCompletion = Convert.ToDouble(dto.Pricing.Completion),
                PricePrompt = Convert.ToDouble(dto.Pricing.Prompt)
            }
        }).ToList();
    }
}