using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


[ApiController]
[Route("[controller]s")]
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
    try{
    var allEvents = await _eventRepository.GetAll();
    return Ok(allEvents);
    }
    catch(Exception)
    {
      return NotFound("Sorry there are no events");
    }
  }

  [HttpGet("{id}")]

  public async Task<IActionResult> GetById(long id)
  {
    try
    {
      var returnedEvent = await _eventRepository.Get(id);
      return Ok(returnedEvent);
    }
    catch(Exception)
    {
      return NotFound("Event not found. Are you sure you have the right id?");
    }
  } 



}


// - Get group by group id
// - Post group
// - Update group
// - Delete group