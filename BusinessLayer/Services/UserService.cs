using System.ComponentModel.DataAnnotations;
using BusinessLayer.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace BusinessLayer.Services;

public class UserService : IUserService
{
    private readonly ILog _logService;
    private readonly IUserValidator _validator;
    private readonly IUserProvider _userProvider;
    private readonly INoteService _noteService;
    private static readonly Dictionary<Guid, User> CachedUsers = new();

    public UserService(ILog logService, IUserValidator validator, IUserProvider userProvider, INoteService noteService)
    {
        _logService = logService;
        _validator = validator;
        _userProvider = userProvider;
        _noteService = noteService;
    }
    public User Create(string login, string password)
    {
        var passwordHash = HashPassword(password);
        var user = new User()
        {
            Id = Guid.NewGuid(),
            Login = login,
            PasswordHash = passwordHash,
        };
        if (!_validator.Validate(user)) throw new Exception("Invalid login or password");
        //if (_userProvider.Create(user))
        {
            CachedUsers.Add(user.Id, user);
            _logService.Log($"Created user {user}");
            return user;
        }
        throw new Exception("User creation failed");
    }

    public User GetById(Guid id)
    {
        //var user = _userProvider.GetById(id);
        var user = CachedUsers[id];
        if (user == null) throw new KeyNotFoundException($"User with id {id} not found");
        _logService.Log($"Get user {user}");
        return user;
    }

    public ICollection<User> GetAll()
    {
        //var users = _userProvider.GetAll();
        var users = CachedUsers.Values.ToList();
        _logService.Log($"Getting all users");
        return users;
    }

    public bool UpdateById(Guid id, User newUser)
    {
        if(!CheckIfUserExistsById(id)) return false;
        if(!_validator.Validate(newUser)) throw new Exception("Invalid login or password");  
        CachedUsers[id] = newUser;
        _logService.Log($"Updated user {newUser}");
        return true;
        //return _userProvider.UpdateById(id, newUser);
    }

    public bool DeleteById(Guid id)
    {
        if (CheckIfUserExistsById(id))
        {
            CachedUsers.Remove(id);
            _logService.Log($"Deleted user {id}");
        };
        return true;
        //return _userProvider.Delete(id);
    }

    private string HashPassword(string password) => password; //TODO 
    private string UnhashPassword(string passwordHash) => passwordHash; //TODO

    private bool CheckIfUserExistsById(Guid id)
    {
        var user = GetById(id);
        if (!_validator.Validate(user)) return false;
        return true;
    }
}