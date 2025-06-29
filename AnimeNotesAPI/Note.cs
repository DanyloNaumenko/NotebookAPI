namespace AnimeNotesAPI;

public abstract record class Note
{
    protected const string NO_DATA = "No data";
    
    protected Note() { }
    public virtual string Title { get; init; } = NO_DATA;
    public virtual string Description { get; init; } = NO_DATA;
    public virtual Guid Id { get; init; }
    public virtual DateTime CreationTime { get; init; } = DateTime.Now;
}
