using System.Collections.Generic;
using System.Threading.Tasks;
public interface IRepository<T>
{
  Task<IEnumerable<T>> GetAll();
  Task<T> Get(long id);

  Task<T> Insert(T t);
  Task<T> Update(T t);

  void Delete(long id);

  Task<IEnumerable<T>> Search(string query);

}