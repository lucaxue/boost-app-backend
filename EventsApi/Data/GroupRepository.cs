using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Threading.Tasks;
using System;
public class GroupRepository : BaseRepository, IRepository<Group>
{

  public GroupRepository(IConfiguration configuration) : base(configuration) { }

  public async Task<IEnumerable<Group>> GetAll()
  {
    using var connection = CreateConnection();
    return await connection.QueryAsync<Group>("SELECT * FROM Groups;");

  }

  public async Task<Group> Get(long id)
  {
    throw new NotImplementedException();
  }

  public async Task<Group> Insert(Group t)
  {
    throw new NotImplementedException();
  }
  public async Task<Group> Update(Group t)
  {
    throw new NotImplementedException();
  }

  public async void Delete(long id)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<Group>> Search(string query)
  {
    throw new NotImplementedException();
  }

}