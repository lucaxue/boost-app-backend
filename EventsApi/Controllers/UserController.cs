using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  private readonly IRepository<User> _userRepository;

  public UserController(IRepository<User> userRepository)
  {
    _userRepository = userRepository;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var allUsers = await _userRepository.GetAll();
    return Ok(allUsers);
  }

}