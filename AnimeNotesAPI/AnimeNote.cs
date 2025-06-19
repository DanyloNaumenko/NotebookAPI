using System.Collections;
using System.Reflection.Metadata;

namespace AnimeNotesAPI;

public class AnimeNote : Note
{
    public AnimeNote(){}
    
    public int Rating { get; set; }
    public DateTime DateOfWatching { get; set; }
    public List<Genre> Genres { get; set; }
    public byte[] Image { get; set; }
    public WathingStatus Status { get; set; }

    public enum Genre
    {
        Horror,
        Comedy,
        Triller,
        Detective,
        Action,
        Adventure,
        Drama,
        Fantasy,
        Sci_fi,
        Mystery,
        Supernatural,
        Psyhological,
        Romance,
        SliceOfLife,
        Mecha,
        Sports,
        Music,
        Historical,
        War,
        Isekai,
        Ecchi,
        Harem,
        ReverceHarem,
        Parody,
        Games,
        School,
        Work,
        Cooking,
        Beastmen
    }
    public enum WathingStatus
    {
        Wished, 
        InProcess,
        Watched
    }
}