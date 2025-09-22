using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController(ChatService chatService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<Chat?>> GetChatAsync(string id)
    {
        var objId = ObjectId.Parse(id);
        var chat = await chatService.GetChatAsync(objId);
        if (chat == null)
        {
            return NotFound();
        }

        return Ok(chat);
    }

    [HttpGet("History")]
    public async Task<ActionResult<ChatHistory?>?> GetChatHistoryAsync()
    {
        var chatHistory = await chatService.GetChatHistoryAsync();
        if (chatHistory == null)
        {
            return NotFound();
        }

        return Ok(chatHistory);
    }

    [HttpGet("Messages/{id}")]
    public async Task<ActionResult<List<Message?>>> GetMessagesAsync(string id)
    {
        var objId = ObjectId.Parse(id);
        var messages = await chatService.GetMessagesAsync(objId);
        return Ok(messages);
    }

    [HttpPost]
    public async Task<ActionResult<ObjectId>> CreateChatAsync([FromBody] Message message)
    {
        var newChatId = await chatService.CreateChatAsync(message);
        return StatusCode(StatusCodes.Status201Created, newChatId);
    }

    [HttpPost("{id}/message")]
    public async Task<ActionResult<ObjectId>> AddMessageToChat(string id, [FromBody] Message message)
    {
        var objId = ObjectId.Parse(id);
        var newMessageId = await chatService.AddMessageToChat(objId, message);
        return StatusCode(StatusCodes.Status201Created, newMessageId);
    }
}