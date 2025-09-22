using Application.Interfaces;
using Domain.Models;
using MongoDB.Bson;

namespace Application.Services;

public class ChatService(IChatRepository chatRepository)
{
    public async Task<Chat?> GetChatAsync(ObjectId id)
    {
        return await chatRepository.GetChatAsync(id);
    }

    public async Task<List<ChatHistory?>?> GetChatHistoryAsync()
    {
        return await chatRepository.GetChatHistoryAsync();
    }

    public async Task<List<Message?>> GetMessagesAsync(ObjectId chatId)
    {
        return await chatRepository.GetMessagesAsync(chatId);
    }

    public async Task<ObjectId> CreateChatAsync(Message message)
    {
        return await chatRepository.CreateChatAsync(message);
    }

    public async Task<ObjectId> AddMessageToChat(ObjectId chatId, Message message)
    {
        return await chatRepository.AddMessageToChat(chatId, message);
    }
}