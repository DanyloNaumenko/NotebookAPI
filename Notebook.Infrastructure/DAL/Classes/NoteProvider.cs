using Notebook.BusinessLayer.DomainModels;
using Notebook.BusinessLayer.Interfaces;

namespace Notebook.Infrastructure.DAL.Classes;

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

    public bool Update(Guid id, Note updatedNote)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}