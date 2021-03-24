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

}