using Microsoft.AspNetCore.Http;
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

        public override void Remove(SuperPowers entity) => base.Remove(entity);

        public override void Update(SuperPowers entity) => base.Update(entity);

        public override async Task<List<SuperPowers>> GetAll() => await base.GetAll();

        public override async Task<SuperPowers> GetById(Guid id) => await base.GetById(id);
    }
}
