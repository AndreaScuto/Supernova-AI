using Application.Interfaces;
using Domain.Models;
using Infrastructure.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public class ChatRepository(IChatDbContext context) : IChatRepository
{
    public async Task<Chat?> GetChatAsync(ObjectId id)
    {
        return await context.Chats.Find(chat => chat.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<ChatHistory?>?> GetChatHistoryAsync()
    {
        return (await context.Chats.Find(_ => true).Project(chat => new ChatHistory
        {
            Id = chat.Id,
            Title = chat.Title
        }).ToListAsync())!;
    }

    public async Task<List<Message?>> GetMessagesAsync(ObjectId chatId)
    {
        return await context.Chats.Find(chat => chat.Id == chatId).Project(chat => chat.Messages).FirstOrDefaultAsync();
    }

    public async Task CreateChatAsync(Message message)
    {
        await context.Chats.InsertOneAsync(new Chat
        {
            Id = new ObjectId(),
            Title = "Titolo di TEST", //TODO: Inserire meccanismo di generazione titolo con AI
            Messages = [message]
        });
    }

    public async Task AddMessageToChat(ObjectId ChatId, Message message)
    {
        await context.Chats.UpdateOneAsync(chat => chat.Id == ChatId,
            Builders<Chat>.Update.Push(chat => chat.Messages, message));
    }
}