namespace AnimeNotesAPI;

public class Note
{
    protected Note() { }

    public Note(string title, string description)
    {
        Title = title;
        Description = description;
        CreationTime = DateTime.Now;
    }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationTime { get; init; } = DateTime.Now;
}