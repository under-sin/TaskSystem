using TaskSystem.Models;

namespace TaskSystem.repositories.Interfaces;

public interface IUserRepository
{
    Task<List<UserModel>> GetAllUsers();
    Task<UserModel> GetById(int id);
    Task<UserModel> Insert(UserModel user);
    Task<UserModel> Update(UserModel user, int id);
    Task<bool> Remove(int id);
}
