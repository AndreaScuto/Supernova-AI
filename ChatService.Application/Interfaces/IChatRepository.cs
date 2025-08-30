using Domain.Models;
using MongoDB.Bson;

namespace Application.Interfaces;

public interface IChatRepository
{
    public Task<Chat?> GetChatAsync(ObjectId id);
    public Task<List<ChatHistory?>> GetChatHistoryAsync();
    public Task<List<Message?>> GetMessagesAsync(ObjectId chatId);
}