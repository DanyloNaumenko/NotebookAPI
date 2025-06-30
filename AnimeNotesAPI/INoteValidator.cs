namespace AnimeNotesAPI;

public interface INoteValidator<TNote> where TNote : Note
{
    bool Validate(TNote note);
}