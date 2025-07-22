using Domain.Interfaces;
using Domain.Models;

namespace DAL.Classes;

//TODO Implement Class
public class NoteProvider : INoteProvider

{
    public Note Create(Note note)
    {
        throw new NotImplementedException();
    }

    public Note GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public ICollection<Note> GetAll()
    {
        throw new NotImplementedException();
    }
    public bool UpdateById(Guid id, Note updatedNote)
    {
        throw new NotImplementedException();
    }

    public bool DeleteById(Guid id)
    {
        throw new NotImplementedException();
    }
}