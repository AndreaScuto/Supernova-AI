using AiModel.Domain.Models;
using AiModel.Infrastructure;

namespace AiModel.Application.Services;

public class AiModelService(OpenRouterClient openRouterClient)
{
    public async Task<List<Ai>?> FetchOpenRouterModels()
    {
        return await openRouterClient.FetchOpenRouterModels();
    }
}