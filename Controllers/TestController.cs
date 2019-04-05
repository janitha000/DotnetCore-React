using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using React.Entity;
using React.Repository.Interfaces;

namespace React.Controllers
{
  [Route("api/[controller]")]
  public class TestController : ControllerBase
  {
    private IUserRepository _repository;

    public TestController(IUserRepository repo)
    {
        this._repository = repo;
    }

    [HttpGet]
    public ActionResult get(){
        return Ok("Test message from server");
    }
    
    [HttpGet("GetAll")]
    public ActionResult GetAll()
    {
        var users = _repository.GetAll();
        return Ok(users);
    }

    [HttpPost("register")]
    public ActionResult<User> Register(User user)
    {
        Console.WriteLine(user.Id);
        Console.WriteLine(user.Name);
        Console.WriteLine(user.Email);

        _repository.Add(user);
        _repository.Commit();
        return Created("User created", user);
    }
  }
}