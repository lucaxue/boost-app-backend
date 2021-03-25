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
        using var connection = CreateConnection();
        return await connection.QuerySingleAsync<Group>("SELECT * FROM Groups WHERE Id=@Id;", new { Id = id });
    }

    public async Task<Group> Insert(Group groupToInsert)
    {
        using var connection = CreateConnection();
        return await connection.QuerySingleAsync<Group>("INSERT INTO Groups(Name) VALUES (@Name)RETURNING *", groupToInsert);
    }
  public async Task<Group> Update(Group groupToUpdate)
  {
    using var connection = CreateConnection();
    return await connection.QuerySingleAsync<Group>("UPDATE Groups SET Name = @Name WHERE Id = @Id RETURNING *;", groupToUpdate);
  }

    public async void Delete(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Group>> Search(string query)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<Group>("SELECT * FROM Groups WHERE Name ILIKE @Name;", new { Name =$"%{query}%" });
    }

}