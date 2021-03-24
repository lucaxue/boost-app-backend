using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Threading.Tasks;
using System;
public class UserRepository : BaseRepository, IRepository<User>
{

  public UserRepository(IConfiguration configuration) : base(configuration) { }

  public async Task<IEnumerable<User>> GetAll()
  {
    using var connection = CreateConnection();
    return await connection.QueryAsync<User>("SELECT * FROM Users;");

  }


  public async Task<User> Get(long id)
  {
    using var connection = CreateConnection();
    return await connection.QuerySingleAsync<User>("SELECT * FROM Users WHERE Id=@Id;", new { Id = id });
  }

  public async Task<User> Insert(User userToInsert)
  {
    using var connection = CreateConnection();
    return await connection.QuerySingleAsync<User>("INSERT INTO Users(FirstName, Surname, Username, Hours, PartOfGroupId, AdminOfGroupId, EventsIds)VALUES (@FirstName, @Surname, @Username, @Hours, @PartOfGroupId, @AdminOfGroupId, @EventsIds)  RETURNING *", userToInsert);
  }
  public async Task<User> Update(User t)
  {
    throw new NotImplementedException();
  }

  public async void Delete(long id)
  {
    using var connection = CreateConnection();
    connection.Execute("DELETE FROM Users WHERE Id = @Id;", new { Id = id });
  }

  public async Task<IEnumerable<User>> SearchById(long id)
  {
    throw new NotImplementedException();
  }

}