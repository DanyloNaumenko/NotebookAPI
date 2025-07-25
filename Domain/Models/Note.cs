namespace Domain.Models
{
    public record class Note
    {
        public string? Title { get; init; }
        public string? Content { get; init; }
        public Guid Id { get; init; }
        public DateTime CreationTime { get; init; }
    }
}


