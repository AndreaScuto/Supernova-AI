using Domain.Models;
using MongoDB.Bson;

namespace Application.Interfaces;

public interface IChatRepository
{
    public Task<Chat?> GetChatAsync(ObjectId id);
    public Task<List<ChatHistory?>?> GetChatHistoryAsync();
    public Task<List<Message?>> GetMessagesAsync(ObjectId chatId);
    public Task<ObjectId> CreateChatAsync(Message message);

    public Task<ObjectId> AddMessageToChat(ObjectId chatId, Message message);
    //TODO: Aggiungere Task per il regen dell'ultimo messaggio
}