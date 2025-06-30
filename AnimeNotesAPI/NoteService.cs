namespace AnimeNotesAPI;

public abstract class NoteService
{
    protected Dictionary<Guid, Note> _cachedNotes = new();

    protected virtual bool AddNewNote(Note note)
    {
        if (!Validation(note))
        {
            throw new ArgumentException("Input data is invalid! The adding was failed.");
        }
        return _cachedNotes.TryAdd(note.Id, note);
        //TODO add logic with database
    }

    protected virtual bool UpdateNoteById(Guid id, Note newNote)
    {
        if (!Validation(newNote))
        {
            throw new ArgumentException("Input data is invalid! Can not apply new note.");
        }
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
        if (!_cachedNotes.ContainsKey(id)) throw new KeyNotFoundException();
        return _cachedNotes.Remove(id);
    }

    protected virtual bool Validation(Note note)
    {
        bool isValid = true;

        if (note.Id == Guid.Empty)
        {
            return false;
        }
        return isValid;
    }
}