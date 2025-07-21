using Domain.Models;

namespace BusinessLayer.Interfaces;

public interface INoteService
{
    public Note Create();
    public Note GetNoteById(Guid id);
    public ICollection<Note> GetAll();
    public bool UpdateNoteById(Guid id, Note newNote);
    public bool DeleteNoteById(Guid id);
}