using SuperHeroes.Domain.Models;
using SuperHeroes.Domain.VOs.SuperPowers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Domain.Interfaces.Repositories
{
    public interface ISuperPowersRepository : IBaseRepository<SuperPowers>
    {
        Task<int> NameIsAvaliable(string name);
        Task<List<SuperPowers>> GetSuperPowersWithSearch(GetSuperPowersWithSearchVO getSuperPowersWithSearchVO);
        Task<int> SuperPowersExists(List<int> ids);
    }
}
