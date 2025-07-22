using Domain.Models;

namespace BusinessLayer.Interfaces;

public interface IUserService
{
    public User Create(string login, string password);
    public User GetById(Guid id);
    public ICollection<User> GetAll();
    public bool UpdateById(Guid Id, User newUser);
    public bool DeleteById(Guid id);
}