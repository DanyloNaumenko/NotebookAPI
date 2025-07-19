using Domain.Models;
using Domain.Interfaces;
using BusinessLayer.Interfaces;
using System.Reflection;

namespace BusinessLayer.Services;

public class NoteService : INoteService
{
    private readonly ILog _logService;
    private readonly INoteValidator _validator;
    private readonly INoteProvider _noteProvider;
    private static readonly Dictionary<Guid, Note> CachedNotes = new();

    public NoteService(ILog logService, INoteValidator validator, INoteProvider noteProvider)
    {
        _logService = logService;
        _validator = validator;
        _noteProvider = noteProvider;
    }
    
    public Note Create()
    {
        var note = _noteProvider.Create();
        AddNoteToCache(note);
        _logService.Log($"Created new note {note.Id} successfully");
        return note;
    }
    public Note GetNoteById(Guid id) 
    {
        //var note = _noteProvider.GetById(id);
        if (!CachedNotes.TryGetValue(id, out var note))
            throw new KeyNotFoundException($"Note with id {id} not found.");
        _logService.Log($"Got note {id} successfully");
        return note;
    }
    public ICollection<Note> GetAll()
    {
        //ICollection<Note> noteList = _noteProvider.GetAll();
        ICollection<Note> noteList = CachedNotes.Values;
        _logService.Log($"Returned list of {noteList.Count} notes");
        return CachedNotes.Values;
    }
    public bool UpdateNoteById(Guid id, Note newNote)
    {
        var result = false;
        if (!ValidateNote(newNote)) return result;

        //result = _noteProvider.Update(id, newNote);
        result = true;
        if (result == true)
        {
            UpdateNoteInCache(id, newNote);
            _logService.Log($"Updated note {id} successfully");
        }
        return result;
    }
    public bool DeleteNoteById(Guid id) 
    {
        var result = false;
        //result = _noteProvider.Delete(id);
        result = true;
        if (result == true)
        {
            DeleteNoteFromCache(id);
            _logService.Log($"Deleted note {id} successfully");
        }
        return result;
    }
    private void UpdateNoteInCache(Guid id, Note newNote)
    {
        if (!CachedNotes.ContainsKey(id))
        {
            _logService.Log($"Note with id {id} not found in cache");
            throw new KeyNotFoundException($"Note with ID {id} not found in cache for update.");
        }
        CachedNotes[id] = newNote;
        _logService.Log($"Updated note {id} in cache successfully");
        
    }
    private void AddNoteToCache(Note note)
    {
        if (!CachedNotes.TryAdd(note.Id, note))
        {
            throw new InvalidOperationException($"Note with ID {note.Id} already exists in cache.");
        }

        _logService.Log($"Added note {note.Id} to cache");
        return;
    }
    private void DeleteNoteFromCache(Guid id)
    {
        if (!CachedNotes.Remove(id))
            throw new KeyNotFoundException($"Note with ID {id} not found in cache.");
        
        _logService.Log($"Deleted note {id} from cache");
        return;
    }
    
    //TODO Integrate FluentValidation
    protected virtual bool ValidateNote(Note note) => _validator.Validate(note);

}
