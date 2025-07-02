using System.ComponentModel.DataAnnotations;

namespace AnimeNotesAPI;

public class NoteService
{
    LogService logService = new();
    private Dictionary<Guid, Note> _cachedNotes { get; } = new();
    private INoteValidator _validator { get; } = new NoteValidator();
    
    public Note Create()
    {
        var note = new Note(); //TODO Create method from NoteProvider returns the note
        AddNoteToCache(note);
        logService.Log($"Created new note {note.Id} successfully");
        return note;
    }
    //Works only with cache
    public Note GetNoteById(Guid id) 
    {
        if (!_cachedNotes.TryGetValue(id, out var note))
            throw new KeyNotFoundException($"Note with id {id} not found.");
        logService.Log($"Got note {id} successfully");
        return note;
    }
    public virtual bool UpdateNoteById(Guid id, Note newNote)
    {
        var result = false;
        if (!ValidateNote(newNote)) return false;
        
        result = true; //TODO Update method from NoteProvider returns boolean
        UpdateNoteInCache(id, newNote);
        logService.Log($"Updated note {newNote.Id} successfully");
        return result; 
    }
    public virtual bool DeleteNoteById(Guid id) 
    {
        var result = false;
        result = true; //TODO Delete method from NoteProvider returns the boolean
        DeleteNoteFromCache(id);
        logService.Log($"Deleted note {id} successfully");
        return result;
    }
    private void UpdateNoteInCache(Guid id, Note newNote)
    {
        try
        {
            _cachedNotes[id] = newNote;
            logService.Log($"Updated note {newNote.Id} in cache");
        }
        catch (Exception e)
        {
            logService.Log(e.Message);
            throw;
        }
        
    }
    private void AddNoteToCache(Note note)
    {
        if (!ValidateNote(note))
        {
            throw new ArgumentException("Input data is invalid! The adding note to cache was failed.");
        }
        _cachedNotes.TryAdd(note.Id, note);
        logService.Log($"Added note {note.Id} to cache");
        return;
    }
    private void DeleteNoteFromCache(Guid id)
    {
        if (!_cachedNotes.ContainsKey(id)) throw new KeyNotFoundException();
        _cachedNotes.Remove(id);
        logService.Log($"Deleted note {id} from cache");
        return;
    }
    
    //TODO Integrate FluentValidation
    protected virtual bool ValidateNote(Note note)
    {
        var isValid = true;

        isValid = _validator.Validate(note);
        return isValid;
    }
}