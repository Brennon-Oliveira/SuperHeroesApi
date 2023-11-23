using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SuperHeroes.Domain.Interfaces.Repositories;
using SuperHeroes.Domain.Models;
using SuperHeroes.Domain.VOs.SuperHeroes;
using SuperHeroes.Domain.VOs.SuperPowers;
using SuperHeroes.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Infra.Data.Repositories
{
    internal class SuperHeroesRepository : BaseRepository<Domain.Models.SuperHeroes>, ISuperHeroesRepository
    {
        public SuperHeroesRepository(AppDbContext context) : base(context)
        {
        }

        public override Task<int> Add(Domain.Models.SuperHeroes entity) => base.Add(entity);

        public override void Remove(int id) => base.Remove(id);

        public override Task<int> Update(Domain.Models.SuperHeroes entity) => base.Update(entity);

        public override async Task<List<Domain.Models.SuperHeroes>> GetAll() => await base.GetAll();

        public override async Task<Domain.Models.SuperHeroes> GetById(int id) => await base.GetById(id);

        public override async Task<int> Exists(int id) => await base.Exists(id);

        public async Task<int> NameIsAvaliable(string name, string heroName)
        {
            return await DbSet.Where(x => x.Name == name || x.HeroName == heroName).CountAsync();
        }

        public async Task<List<Domain.Models.SuperHeroes>> GetSuperHeroesWithSearch(GetSuperHeroesWithSearchVO getSuperHeroesWithSearchVO)
        {

            string search = getSuperHeroesWithSearchVO.Search ?? "";
            return await DbSet
                .Where(x => x.Name.Contains(search) || x.HeroName.Contains(search))
                .Skip(getSuperHeroesWithSearchVO.Page * getSuperHeroesWithSearchVO.PageSize)
                .Take(getSuperHeroesWithSearchVO.PageSize)
                .ToListAsync();
        }
    }
}
