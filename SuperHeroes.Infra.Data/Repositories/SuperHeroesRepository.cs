using Microsoft.AspNetCore.Http;
using SuperHeroes.Domain.Interfaces.Repositories;
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

        public override void Remove(Domain.Models.SuperHeroes entity) => base.Remove(entity);

        public override void Update(Domain.Models.SuperHeroes entity) => base.Update(entity);

        public override async Task<List<Domain.Models.SuperHeroes>> GetAll() => await base.GetAll();

        public override async Task<Domain.Models.SuperHeroes> GetById(Guid id) => await base.GetById(id);
    }
}
