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
        Task<List<GetFullSuperPowerVO>> GetSuperPowersWithSearch(GetSuperPowersWithSearchVO getSuperPowersWithSearchVO);
        Task<List<GetFullSuperPowerVO>> GetAllFull();
        Task<GetFullSuperPowerVO> GetFull(int id);
        Task<int> SuperPowersExists(List<int> ids);
    }
}
