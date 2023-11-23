using SuperHeroes.Domain.VOs.SuperHeroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Domain.Interfaces.Actions
{
    public interface ISuperHeroesActions
    {
        public Task<int> Create(CreateSuperHeroVO createSuperHeroVO);
        Task<int> Update(UpdateSuperHeroVO updateSuperHeroVO);
        void Delete(int id);
    }
}
