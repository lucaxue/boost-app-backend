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
  public async Task<IActionResult> GetAll()
  {
    var allUsers = await _groupRepository.GetAll();
    return Ok(allUsers);
  }

}