namespace AiModel.Domain.Models;

public class AiModel
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public long ReleaseDate { get; set; }
    public string? Description { get; set; }
    public long ContextLength { get; set; }
    public required Pricing Pricing { get; set; }
}