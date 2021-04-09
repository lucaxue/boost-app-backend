using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;

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
  public async Task<IActionResult> Get(string groupId)
  {
    try
    {
      if (groupId != null)
      {
        var searchedByGroupIdResults = await _eventRepository.Search(groupId);
        // return Ok(searchedByGroupIdResults.OrderBy((eachEvent) => eachEvent.Time));
        return Ok(searchedByGroupIdResults);

      }
      var allEvents = await _eventRepository.GetAll();
      return Ok(allEvents);
    }
    catch (Exception)
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
    catch (Exception)
    {
      return NotFound("Event not found. Are you sure you have the right id?");
    }
  }

  [HttpPost]

  public async Task<IActionResult> Post([FromBody] Event eventToPost)
  {
    try
    {
      var postedEvent = await _eventRepository.Insert(eventToPost);
      return Created($"/events/{postedEvent.Id}", postedEvent);
    }
    catch (Exception)
    {
      return BadRequest("Sorry can not insert your event, is it valid?");
    }
  }

  [HttpPut("{id}")]

  public async Task<IActionResult> Put(long id, [FromBody] Event eventToPut)
  {
    try
    {
      eventToPut.Id = id;
      var updatedEvent = await _eventRepository.Update(eventToPut);
      return Ok(updatedEvent);
    }
    catch (Exception)
    {
      return BadRequest("Sorry can not update your event. Is your id and your event valid?");
    }
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(long id)
  {
    try
    {
      _eventRepository.Delete(id);
      return Ok($"Event at id {id} is successfully deleted.");
    }
    catch (Exception)
    {
      return BadRequest($"Sorry, event of id {id} cannot be deleted, since it does not exit.\nAre you sure the id is correct?");
    }
  }

}



