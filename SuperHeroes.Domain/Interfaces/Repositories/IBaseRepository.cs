﻿using SuperHeroes.Domain.Models;

namespace SuperHeroes.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<int> Add(T entity);
        void Dispose();
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> SaveChanges();
        Task Remove(int id);
        Task<int> Update(T entity);
        Task<int> Exists(int id);
        Task<int> GetCount();
    }
}