using Domain.Models.Enums;

namespace Domain.Models;

public record AnimeNote : Note
{
    public int Rating { get; init; }
    public TimeSpan PeriodOfWatching { get; init; }
    public List<Genres> Genres { get; init; } = new();
    public byte[] Image { get; init; } = Array.Empty<byte>();
    public WatchingStatus Status { get; init; }
}