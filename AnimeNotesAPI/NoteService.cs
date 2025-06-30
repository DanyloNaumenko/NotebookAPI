using System.ComponentModel.DataAnnotations;

namespace AnimeNotesAPI;

public class NoteService<TNote> where TNote : Note, new()
{
    private Dictionary<Guid, TNote> _cachedNotes { get; } = new();
    private INoteValidator<TNote> _validator { get; }
    
    public NoteService(INoteValidator<TNote> validator){_validator = validator;}
    public TNote CreateNote()
    {
        TNote note = new TNote(); //TODO Create method from NoteProvider returns the note
        note.Create();
        AddNoteToCache(note);
        return note;
    }
    //Works only with cache
    public TNote GetNoteById(Guid id) 
    {
        if (!_cachedNotes.TryGetValue(id, out var note))
            throw new KeyNotFoundException($"Note with id {id} not found.");
        return note;
    }
    public virtual bool UpdateNoteById(Guid id, TNote newNote)
    {
        bool result = false;
        if (!ValidateNote(newNote)) return false;
        
        result = true; //TODO Update method from NoteProvider returns boolean
        UpdateNoteInCache(id, newNote);
        return result; 
    }
    public virtual bool DeleteNoteById(Guid id) 
    {
        bool result = false;
        result = true; //TODO Delete method from NoteProvider returns the boolean
        DeleteNoteFromCache(id);
        return result;
    }
    private void UpdateNoteInCache(Guid id, TNote newNote)
    {
        if(!_cachedNotes.ContainsKey(id)) throw new KeyNotFoundException($"Note with id {id} not found.");
        _cachedNotes[id] = newNote;
    }
    private void AddNoteToCache(TNote note)
    {
        if (!ValidateNote(note))
        {
            throw new ArgumentException("Input data is invalid! The adding to cache was failed.");
        }
        _cachedNotes.TryAdd(note.Id, note);
    }
    private void DeleteNoteFromCache(Guid id)
    {
        if (!_cachedNotes.ContainsKey(id)) throw new KeyNotFoundException();
        _cachedNotes.Remove(id);
    }
    protected virtual bool ValidateNote(TNote note)
    {
        bool isValid = true;

        isValid = _validator.Validate(note);
        return isValid;
    }
}