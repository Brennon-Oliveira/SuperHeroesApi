using SuperHeroes.Domain.Interfaces.Repositories;
using SuperHeroes.Domain.Models;
using SuperHeroes.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroes.Infra.Data.Repositories
{
    internal class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {

        protected readonly AppDbContext Db;
        protected readonly DbSet<T> DbSet;

        //User
        protected readonly Guid UserId;


        public BaseRepository(
            AppDbContext context
        )
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<int> Add(T entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
            return entity.Id;
        }

        public virtual void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

    }
}
