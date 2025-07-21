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
    public Note Create(string title, string content)
    {
        var note = new Note()
        {
            Id = Guid.NewGuid(),
            Title = title,
            Content = content,
        };
        if (!_validator.Validate(note)) throw new Exception("Validation failed");
        //if (_noteProvider.Create(note))
        {
            CachedNotes.Add(note.Id, note);
            _logService.Log($"Created note {note}");
            return note;
        }
        throw new Exception("Note creation failed");
    }

    public Note GetNoteById(Guid id) 
    {
        //var note = _noteProvider.GetById(id);
        if (!CachedNotes.TryGetValue(id, out var note))
            throw new KeyNotFoundException($"Note with id {id} not found.");
        _logService.Log($"Getting note {note}");
        return note;
    }
    public ICollection<Note> GetAll()
    {
        //ICollection<Note> notes = _noteProvider.GetAll();
        ICollection<Note> notes = CachedNotes.Values;
        _logService.Log($"Getting all notes({CachedNotes.Count})");
        return notes;
    }

    public bool UpdateNoteById(Guid id, Note newNote)
    {
        if(!CheckIfNoteExistsById(id)) return false;
        if(!_validator.Validate(newNote)) throw new Exception("Validation failed");  
        CachedNotes[id] = newNote;
        _logService.Log($"Updated user {newnote}");
        return true;
        //return _userProvider.UpdateById(id, newUser);
    }
    public bool DeleteNoteById(Guid id) 
    {
        if (CheckIfNoteExistsById(id))
        {
            CachedNotes.Remove(id);
            _logService.Log($"Deleted user {id}");
        };
        return true;
        //return _userProvider.DeleteById(id);
    }
    
    private bool CheckIfNoteExistsById(Guid id)
    {
        var note = GetNoteById(id);
        return !_validator.Validate(note);
    }
    //TODO Integrate FluentValidation
    protected virtual bool ValidateNote(Note note) => _validator.Validate(note);
}
