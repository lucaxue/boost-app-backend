using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Threading.Tasks;
public class UserRepository : BaseRepository, IRepository<User>
{

  public UserRepository(IConfiguration configuration) : base(configuration) { }

  public async Task<IEnumerable<User>> GetAll()
  {
    using var connection = CreateConnection();
    return await connection.QueryAsync<User>("SELECT * FROM Users;");

  }

}