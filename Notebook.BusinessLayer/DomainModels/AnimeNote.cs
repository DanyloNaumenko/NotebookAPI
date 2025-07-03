using Notebook.BusinessLayer.Enums;

namespace Notebook.BusinessLayer.DomainModels;

public record AnimeNote : Note
{
    public int Rating { get; init; }
    public TimeSpan PeriodOfWatching { get; init; }
    public List<Genres> Genres { get; init; }
    public byte[] Image { get; init; }
    public WatchingStatus Status { get; init; }
}