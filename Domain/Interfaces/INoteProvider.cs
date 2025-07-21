using Domain.Models;

namespace Domain.Interfaces;

public interface INoteProvider
{
    public Note Create();
    public Note GetById(Guid id);
    public ICollection<Note> GetAll();
    public bool Update(Guid id, Note updatedNote);
    public bool Delete(Guid id);
}