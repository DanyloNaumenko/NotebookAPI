using Domain.Interfaces;
using Domain.Models;

namespace DAL.Classes;

//TODO Implement Class
public class NoteProvider : INoteProvider

{
    public Note Create()
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
    public bool Update(Guid id, Note updatedNote)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}