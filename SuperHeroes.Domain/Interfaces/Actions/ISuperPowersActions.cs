using SuperHeroes.Domain.VOs.SuperPowers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Domain.Interfaces.Actions
{
    public interface ISuperPowersActions
    {
        public Task<int> Create(CreateSuperPowerVO createSuperPowerVO);
    }
}
