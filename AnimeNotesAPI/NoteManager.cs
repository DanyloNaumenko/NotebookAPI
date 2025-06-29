namespace AnimeNotesAPI;

public abstract class NoteManager
{
    protected Dictionary<Guid, Note> _cachedNotes = new();

    protected virtual bool AddNewNote(Note note)
    {
        return _cachedNotes.TryAdd(note.Id, note);
        //TODO add logic with database
    }

    protected virtual bool UpdateNoteById(Guid id, Note newNote)
    {
        if (!_cachedNotes.ContainsKey(id)) throw new KeyNotFoundException();
        _cachedNotes[id] = newNote;
        //TODO add logic with database
        return true;
    }

    protected virtual Note GetNoteById(Guid id)
    {
        if (!_cachedNotes.TryGetValue(id, out var note))
            throw new KeyNotFoundException($"Note with id {id} not found.");
        return note;
    }

    protected virtual bool DeleteNoteById(Guid id)
    {
        //TODO add logic with database
        return _cachedNotes.Remove(id);
    }
}