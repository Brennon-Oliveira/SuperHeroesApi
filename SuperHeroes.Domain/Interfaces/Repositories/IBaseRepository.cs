using SuperHeroes.Domain.Models;

namespace SuperHeroes.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        void Add(T entity);
        void Dispose();
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<int> SaveChanges();
        void Remove(T entity);
        void Update(T entity);
    }
}