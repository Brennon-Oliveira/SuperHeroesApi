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

        public virtual async Task<T> GetById(int id)
        {
            return await DbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
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

        public async virtual Task Remove(int id)
        {
            DbSet.Where(x => x.Id == id).ExecuteDelete();
            await SaveChanges();
        }

        public virtual async Task<int> Update(T entity)
        {
            var props = entity.GetType().GetProperties();
            var newEntity = await DbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
            foreach (var prop in props)
            {
                if (prop.Name == "Id")
                {
                    continue;
                }
                if(prop.GetValue(entity) != null)
                {
                    newEntity.GetType().GetProperty(prop.Name).SetValue(newEntity, prop.GetValue(entity));
                }
            }
            DbSet.Update(newEntity);
            await SaveChanges();
            return entity.Id;
        }

        public virtual async Task<int> Exists(int id)
        {
            return await DbSet.Where(x => x.Id == id).CountAsync();
        }
        public async Task<int> GetCount()
        {
            return await DbSet.CountAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }


    }
}
