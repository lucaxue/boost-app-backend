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
    throw new NotImplementedException();
  }

  public async Task<User> Insert(User t)
  {
    throw new NotImplementedException();
  }
  public async Task<User> Update(User t)
  {
    throw new NotImplementedException();
  }

  public async void Delete(long id)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<User>> SearchById(long id)
  {
    throw new NotImplementedException();
  }

}