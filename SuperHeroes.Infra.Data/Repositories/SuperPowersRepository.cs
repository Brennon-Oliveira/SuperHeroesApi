using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SuperHeroes.Domain.Interfaces.Repositories;
using SuperHeroes.Domain.Models;
using SuperHeroes.Domain.VOs.SuperPowers;
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

        public override Task Remove(int id) => base.Remove(id);

        public override Task<int> Update(SuperPowers entity) => base.Update(entity);

        public override async Task<List<SuperPowers>> GetAll() => await base.GetAll();

        public override async Task<SuperPowers> GetById(int id) => await base.GetById(id);

        public override async Task<int> Exists(int id) => await base.Exists(id);

        public async Task<int> NameIsAvaliable(string name)
        {
            return await DbSet.Where(x => x.Name == name).CountAsync();
        }

        public async Task<List<SuperPowers>> GetSuperPowersWithSearch(GetSuperPowersWithSearchVO getSuperPowersWithSearchVO)
        {
            return await DbSet
                .Where(x => x.Name.Contains(getSuperPowersWithSearchVO.Search ?? ""))
                .Skip(getSuperPowersWithSearchVO.Page * getSuperPowersWithSearchVO.PageSize)
                .Take(getSuperPowersWithSearchVO.PageSize)
                .ToListAsync();
        }

        public Task<int> SuperPowersExists(List<int> ids)
        {
            return DbSet.Where(x => ids.Contains(x.Id)).CountAsync();
        }
    }
}
