using Domain.Models;

namespace BusinessLayer.Interfaces;

public interface INoteValidator
{
    bool Validate(Note note);
}