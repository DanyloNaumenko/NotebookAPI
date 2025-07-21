using BusinessLayer.Interfaces;
using Domain.Models;

namespace BusinessLayer.Services;

public class UserValidator : IUserValidator
{
    public bool Validate(User user)
    {
        if (user.Id != Guid.Empty && user.PasswordHash != string.Empty && user.Login != string.Empty) return true;
        return false;
    }
}