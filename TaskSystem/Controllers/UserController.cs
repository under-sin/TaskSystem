using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.repositories.Interfaces;

namespace TaskSystem.Controllers;

[ApiController]
[Route("api/[controller]")] // api/nome da controller
public class UserController : ControllerBase
{
    private readonly IUserRepository _repositorey;

    public UserController(IUserRepository repository)
    {
        _repositorey = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserModel>>> GetAllUsers()
    {
        List<UserModel> users = await _repositorey.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserModel>> GetById(int id)
    {
        UserModel user = await _repositorey.GetById(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserModel>> Insert([FromBody] UserModel userModel)
    {
        UserModel user = await _repositorey.Insert(userModel);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
    {
        userModel.Id = id;
        UserModel user = await _repositorey.Update(userModel, id);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UserModel>> Remove(int id)
    {
        bool removed = await _repositorey.Remove(id);
        return Ok(removed);
    }
}