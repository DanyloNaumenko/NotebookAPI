using Domain.Models;

namespace BusinessLayer.Interfaces;

public interface IUserService
{
    public User Create(string login, string password);
    public User GetById(Guid id);
    public User GetByLogin(string login);
    public ICollection<User> GetAll();
    public bool UpdateById(Guid Id, User newUser);
    public bool DeleteById(Guid id);
        
    public bool AddNoteToUser<TNote> (TNote note) where TNote : Note; 
}