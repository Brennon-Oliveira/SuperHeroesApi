using SuperHeroes.Domain.Models;
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
        Task<int> Exists(int id);
    }
}
