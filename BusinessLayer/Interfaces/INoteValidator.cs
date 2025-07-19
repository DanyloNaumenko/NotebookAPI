using Domain.Models;

namespace BusinessLayer.Interfaces;

public interface INoteValidator
{
    public bool Validate(Note note);
}