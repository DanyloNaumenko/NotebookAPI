using Domain.Models;

namespace Domain.Interfaces;

public interface INoteProvider
{
    public Note Create(Note note);
    public Note GetById(Guid id);
    public ICollection<Note> GetAll();
    public bool UpdateById(Guid id, Note updatedNote);
    public bool DeleteById(Guid id);
}