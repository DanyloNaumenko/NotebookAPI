using Domain.Models;

namespace BusinessLayer.Interfaces;

public interface INoteService
{
    Note Create();
    Note GetNoteById(Guid id);
    bool UpdateNoteById(Guid id, Note newNote);
    bool DeleteNoteById(Guid id);
}