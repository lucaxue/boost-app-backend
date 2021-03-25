using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


[ApiController]
[Route("[controller]s")]
public class GroupController : ControllerBase
{
  private readonly IRepository<Group> _groupRepository;

  public GroupController(IRepository<Group> groupRepository)
  {
    _groupRepository = groupRepository;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll(string name)
  {
    try
    { 
      if (name != null)
      {
        var searchByNameResults = await _groupRepository.Search(name);
        return Ok(searchByNameResults);
      }
    var allGroups = await _groupRepository.GetAll();
    return Ok(allGroups);
    }
    catch (Exception)
    {
      return NotFound("Sorry, there are no users.");
    }
  }
}