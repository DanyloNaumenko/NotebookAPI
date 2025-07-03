namespace Notebook.Infrastructure.DAL.Models
{
    public record class Note
    {
        public string? Title { get; init; }
        public string? Description { get; init; }
        public Guid Id { get; init; }
        public DateTime CreationTime { get; init; }
    }
}


