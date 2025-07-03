using Notebook.BusinessLayer.DomainModels;

namespace Notebook.BusinessLayer.Interfaces;

public interface INoteValidator
{
    bool Validate(Note note);
}