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

        public async Task<int> NameIsAvaliable(string name , int id)
        {
            return await DbSet.Where(x => x.Name == name && id != x.Id).CountAsync();
        }

        public async Task<List<GetFullSuperPowerVO>> GetAllFull()
        {
            return await DbSet
                .Select(x => new GetFullSuperPowerVO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                })
                .ToListAsync();
        }

        public async Task<GetFullSuperPowerVO?> GetFull(int id)
        {
            return await DbSet
                .Where(x => x.Id == id)
                .Select(x => new GetFullSuperPowerVO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<GetFullSuperPowerVO>> GetSuperPowersWithSearch(GetSuperPowersWithSearchVO getSuperPowersWithSearchVO)
        {
            return await DbSet
                .Where(x => x.Name.ToLower().Contains((getSuperPowersWithSearchVO.Search ?? "").ToLower()))
                .Skip((getSuperPowersWithSearchVO.Page-1) * getSuperPowersWithSearchVO.PageSize)
                .Take(getSuperPowersWithSearchVO.PageSize)
                .Select(x => new GetFullSuperPowerVO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                })
                .ToListAsync();
        }

        public Task<int> SuperPowersExists(List<int> ids)
        {
            return DbSet.Where(x => ids.Contains(x.Id)).CountAsync();
        }
    }
}
