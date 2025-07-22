using Domain.Models;

namespace Domain.Interfaces;

public interface IUserProvider
{
    public bool Create(User user);
    public User GetById(Guid id);
    public ICollection<User> GetAll();
    public bool UpdateById(Guid id, User updatedUser);
    public bool DeleteById(Guid id);
}