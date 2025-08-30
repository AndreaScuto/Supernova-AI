using AiModel.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using AiModel.Application.Services;

namespace AiModel.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AiModelController(AiModelService aiModelService) : ControllerBase
{
    [HttpGet("AiModels")]
    public async Task<ActionResult<List<Ai>?>> GetAiModels()
    {
        var aiModels = await aiModelService.FetchOpenRouterModels();
        if (aiModels is null)
        {
            return NotFound();
        }

        return Ok(aiModels);
    }
}