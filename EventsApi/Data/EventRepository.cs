using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Threading.Tasks;
public class EventRepository : BaseRepository, IRepository<Event>
{

  public EventRepository(IConfiguration configuration) : base(configuration) { }

  public async Task<IEnumerable<Event>> GetAll()
  {
    using var connection = CreateConnection();
    return await connection.QueryAsync<Event>("SELECT * FROM Events;");

  }

  public async Task<Event> Get(long id)
  {
    using var connection = CreateConnection();
    return await connection.QuerySingleAsync<Event>("SELECT * FROM Events WHERE Id=@Id;", new{Id=id});
  }

  public async Task<Event> Insert(Event eventToInsert)
  {
    using var connection = CreateConnection();
    return await connection.QuerySingleAsync<Event>("INSERT INTO Events(Name, Description, ExerciseType, Longitude, Latitude, Time, Intensity, GroupId)VALUES);
  }

}