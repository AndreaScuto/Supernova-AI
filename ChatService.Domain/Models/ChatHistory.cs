using MongoDB.Bson;

namespace Domain.Models;

public class ChatHistory
{
    public ObjectId Id { get; set; }
    public string Title { get; set; }
}