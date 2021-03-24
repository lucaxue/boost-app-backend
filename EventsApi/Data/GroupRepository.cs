using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Threading.Tasks;
public class GroupRepository : BaseRepository, IRepository<Group>
{

  public GroupRepository(IConfiguration configuration) : base(configuration) { }

  public async Task<IEnumerable<Group>> GetAll()
  {
    using var connection = CreateConnection();
    return await connection.QueryAsync<Group>("SELECT * FROM Groups;");

  }

}