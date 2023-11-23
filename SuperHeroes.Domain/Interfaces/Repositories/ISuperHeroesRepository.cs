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
    }
}
