using SuperHeroes.Domain.Interfaces.Repositories;
using SuperHeroes.Domain.Models;
using SuperHeroes.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace SuperHeroes.Infra.Data.Repositories
{
    internal class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {

        protected readonly AppDbContext Db;
        protected readonly DbSet<T> DbSet;

        //User
        protected readonly Guid UserId;


        public BaseRepository(
            AppDbContext context,
            HttpContextAccessor httpContextAccessor
        )
        {
            Db = context;
            DbSet = Db.Set<T>();
            UserId = new Guid(httpContextAccessor.HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value);
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

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
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
