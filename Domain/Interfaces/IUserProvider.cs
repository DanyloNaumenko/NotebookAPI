using Domain.Models;

namespace Domain.Interfaces;

public interface IUserProvider
{
    public User Create();
    public User GetById(Guid id);
    public ICollection<User> GetAll();
    public bool Update(Guid id, User updatedUser);
    public bool Delete(Guid id);
}