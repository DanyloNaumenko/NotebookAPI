namespace AnimeNotesAPI;

public record class Note
{
    protected const string NO_DATA = "No data";
    protected Note() { }

    internal Note Create()
    {
        Note note = new Note();
        return note;
    }
    public string Title { get; init; } = NO_DATA;
    public string Description { get; init; } = NO_DATA;
    public Guid Id { get; init; }
    public DateTime CreationTime { get; init; } = DateTime.Now;
}
