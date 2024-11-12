using asp.Models;

namespace asp.DataAccess.Repository.IRepository;

public interface IGategoryRepository : IRepository<Category>
{
    void Update(Category obj);
    void Save();

}