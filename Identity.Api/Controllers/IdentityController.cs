using IdentityService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController(Application.Services.IdentityService identityService) : ControllerBase
{
    [HttpGet("Users")]
    public async Task<ActionResult<List<User>>?> GetUsers()
    {
        var users = await identityService.GetAllUsersAsync();
        if (users == null)
        {
            return NotFound();
        }

        return Ok(users);
    }
}