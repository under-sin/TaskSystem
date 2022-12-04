using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.repositories.Interfaces;

namespace TaskSystem.repositories;

public class UserRepository : IUserRepository
{
    private readonly TaskSystemDBContext _context;

    public UserRepository(TaskSystemDBContext context)
    {
        _context = context;
    }

    public async Task<UserModel> GetById(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<UserModel>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<UserModel> Insert(UserModel user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<UserModel> Update(UserModel user, int id)
    {
        UserModel userById = await GetById(id);
        if (userById == null)
            throw new Exception($"Não foi encontrado o usuário com o id: {id}");

        userById.Name = user.Name;
        userById.Email = user.Email;

        _context.Users.Update(userById);
        await _context.SaveChangesAsync();

        return userById;
    }

    public async Task<bool> Remove(int id)
    {
        UserModel userById = await GetById(id);
        if (userById == null)
            throw new Exception($"Não foi encontrado o usuário com o id: {id}");

        _context.Users.Remove(userById);
        await _context.SaveChangesAsync();

        return true;
    }
}
