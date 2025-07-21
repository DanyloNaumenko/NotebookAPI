namespace Domain.Models;

public record class User
{
    public string Login { get; init; }
    public string Password { get; init; }
    
    public List<Note> Notes { get; init; }
}