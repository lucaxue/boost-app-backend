using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
  private readonly IRepository<Event> _eventRepository;

  public EventController(IRepository<Event> eventRepository)
  {
    _eventRepository = eventRepository;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var allUsers = await _eventRepository.GetAll();
    return Ok(allUsers);
  }

}