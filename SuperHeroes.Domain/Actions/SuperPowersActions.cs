using SuperHeroes.Domain.Interfaces.Actions;
using SuperHeroes.Domain.VOs.SuperPowers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Domain.Actions
{
    public class SuperPowersActions : ISuperPowersActions
    {
        public Task<int> Create(CreateSuperPowerVO createSuperPowerVO)
        {
            if(createSuperPowerVO is null)
            {
                throw new ArgumentNullException(nameof(createSuperPowerVO));
            }

            if(string.IsNullOrWhiteSpace(createSuperPowerVO.Name))
            {
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(createSuperPowerVO.Name));
            }

            throw new NotImplementedException();
        }
    }
}
