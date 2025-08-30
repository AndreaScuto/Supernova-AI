namespace AiModel.Domain.Models;

public class Ai
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required long ReleaseDate { get; set; }
    public string? Description { get; set; }
    public required long ContextLength { get; set; }
    public required Pricing Pricing { get; set; }
}