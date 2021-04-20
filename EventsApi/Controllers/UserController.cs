using System.Collections.Generic;
using System.Linq;
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
        if (searchedByUsernameResults.Any())
        {
          return Ok(searchedByUsernameResults);
        }
        return NotFound($"Sorry, there is no user with the username of {username}");
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
      return Created($"/users/{postedUser.Id}", postedUser);
    }
    catch (Exception)
    {
      return BadRequest("Sorry can not insert your user, is it valid?\nTry another username");
    }
  }


  [HttpDelete("{id}")]
  public IActionResult Delete(long id)
  {
    try
    {
      _userRepository.Delete(id);
      return Ok($"User at id {id} is successfully deleted.");
    }
    catch (Exception)
    {
      return BadRequest($"Sorry, user of id {id} cannot be deleted, since it does not exit.\nAre you sure the id is correct?");
    }
  }


  [HttpPut("{id}")]

  public async Task<IActionResult> Put(long id, [FromBody] User userToPut)
  {
    try
    {
      userToPut.Id = id;
      var updatedUser = await _userRepository.Update(userToPut);
      return Ok(updatedUser);
    }
    catch (Exception)
    {
      return BadRequest("Sorry can not update your user. Is your id and your user valid?");
    }
  }

}



