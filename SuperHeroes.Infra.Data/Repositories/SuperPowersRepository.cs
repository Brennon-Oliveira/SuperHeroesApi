using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SuperHeroes.Domain.Interfaces.Repositories;
using SuperHeroes.Domain.Models;
using SuperHeroes.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Infra.Data.Repositories
{
    internal class SuperPowersRepository : BaseRepository<SuperPowers>, ISuperPowersRepository
    {
        public SuperPowersRepository(AppDbContext context) : base(context)
        {
        }

        public override Task<int> Add(SuperPowers entity) => base.Add(entity);

        public override void Remove(int id) => base.Remove(id);

        public override Task<int> Update(SuperPowers entity) => base.Update(entity);

        public override async Task<List<SuperPowers>> GetAll() => await base.GetAll();

        public override async Task<SuperPowers> GetById(int id) => await base.GetById(id);

        public async Task<int> NameIsAvaliable(string name)
        {
            return await DbSet.Where(x => x.Name == name).CountAsync();
        }

        public async Task<int> Exists(int id)
        {
            return await DbSet.Where(x => x.Id == id).CountAsync();
        }
    }
}
