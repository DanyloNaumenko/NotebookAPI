namespace AnimeNotesAPI;

public class NoteValidator : INoteValidator<Note>
{
    public bool Validate(Note note)
    {
        if (note == null) throw new ArgumentNullException();
        if (note.Id == Guid.Empty) return false;

        return true;
    }
}