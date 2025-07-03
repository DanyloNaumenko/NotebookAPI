using Notebook.BusinessLayer.DomainModels;

namespace Notebook.BusinessLayer.Interfaces;

public interface INoteProvider
{
    Note Create();
    Note GetById(Guid id);
    bool Update(Guid id, Note updatedNote);
    bool Delete(Guid id);
}
