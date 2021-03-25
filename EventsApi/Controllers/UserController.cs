using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


[ApiController]
[Route("[controller]s")]
public class UserController : ControllerBase
{
  private readonly IRepository<User> _userRepository;

  public UserController(IRepository<User> userRepository)
  {
    _userRepository = userRepository;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll(string groupId, string username)
  {
    try
    {
      //if group is is not null
      //search by group id with repo
      if (groupId != null)
      {
        var searchedByGroupIdResults = await _userRepository.Search(groupId);
        return Ok(searchedByGroupIdResults);
      }
      if (username != null)
      {
        var searchedByUsernameResults = await _userRepository.Search(username);
        return Ok(searchedByUsernameResults);
      }
      var allUsers = await _userRepository.GetAll();
      return Ok(allUsers);
    }
    catch (Exception)
    {
      return NotFound("Sorry, there are no users.");
    }
  }


[HttpGet("{id}")]

  public async Task<IActionResult> GetById(long id)
  {
    try
    {
      var returnedUser = await _userRepository.Get(id);
      return Ok(returnedUser);
    }
    catch (Exception)
    {
      return NotFound("User not found. Are you sure you have the right id?");
    }
  }


[HttpPost]

  public async Task<IActionResult> Post([FromBody] User userToPost)
  {
    try
    {
      var postedUser = await _userRepository.Insert(userToPost);
      return Created($"/events/{postedUser.Id}", postedUser);
    }
    catch (Exception)
    {
      return BadRequest("Sorry can not insert your user, is it valid?");
    }
  }

}




// - Post user
// - Update user
// - Delete user