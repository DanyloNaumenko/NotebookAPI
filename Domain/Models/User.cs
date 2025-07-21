namespace Domain.Models;

public record class User
{
    public Guid Id { get; init; }
    public string Login { get; init; }
    public string Password { get; init; }
    
    public ICollection<Note> Notes { get; init; }
}