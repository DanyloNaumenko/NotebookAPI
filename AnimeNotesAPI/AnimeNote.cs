using System.Collections;
using System.Reflection.Metadata;
using AnimeNotesAPI.enums;

namespace AnimeNotesAPI;

public record class AnimeNote : Note
{
    public int Rating { get; init; }
    public TimeSpan DateOfWatching { get; init; }
    public List<Genres> Genres { get; init; } = new();
    public byte[] Image { get; init; } = Array.Empty<byte>();
    public WatchingStatus Status { get; init; }
}