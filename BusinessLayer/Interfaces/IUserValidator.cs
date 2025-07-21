using Domain.Models;

namespace BusinessLayer.Interfaces;

public interface IUserValidator
{
    public bool Validate(User user);
}