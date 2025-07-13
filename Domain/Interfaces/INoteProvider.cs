using Domain.Models;

namespace Domain.Interfaces;

public interface INoteProvider
{
    Note Create();
    Note GetById(Guid id);
    ICollection<Note> GetAll();
    bool Update(Guid id, Note updatedNote);
    public bool Delete(Guid id);
}