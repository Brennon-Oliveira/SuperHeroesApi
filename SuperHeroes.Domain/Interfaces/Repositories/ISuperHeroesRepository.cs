using SuperHeroes.Domain.Models;
using SuperHeroes.Domain.VOs.SuperHeroes;
using SuperHeroes.Domain.VOs.SuperPowers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Domain.Interfaces.Repositories
{
    public interface ISuperHeroesRepository : IBaseRepository<Models.SuperHeroes>
    {
        Task<int> NameIsAvaliable(string name, string heroName);
        Task<List<GetFullSuperHeroVO>> GetSuperHeroesWithSearch(GetSuperHeroesWithSearchVO getSuperHeroesWithSearchVO);
        Task AddSuperPowers(int superHeroId, List<int> superPowers);
        Task<List<GetFullSuperHeroVO>> GetAllFull();
        Task<GetFullSuperHeroVO> GetFullHero(int id);
    }
}
