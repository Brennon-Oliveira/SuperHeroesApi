using SuperHeroes.Domain.Interfaces.Actions;
using SuperHeroes.Domain.Interfaces.Repositories;
using SuperHeroes.Domain.Models;
using SuperHeroes.Domain.VOs.SuperPowers;
using SuperHeroes.Infra.CrossCutting.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Domain.Actions
{
    public class SuperPowersActions : ISuperPowersActions
    {
        private readonly ISuperPowersRepository _superPowersRepository = ServiceLocator.GetService<ISuperPowersRepository>();
        public async Task<int> Create(CreateSuperPowerVO createSuperPowerVO)
        {
            if(createSuperPowerVO is null)
            {
                throw new ArgumentNullException(nameof(createSuperPowerVO));
            }

            if(string.IsNullOrWhiteSpace(createSuperPowerVO.Name))
            {
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(createSuperPowerVO.Name));
            }

            SuperPowers superPower = new SuperPowers
            {
                Name = createSuperPowerVO.Name,
                Description = createSuperPowerVO.Description
            };

            int id = await _superPowersRepository.Add(superPower);
            return id;
        }

        public void Delete(int id)
        {
            _superPowersRepository.Remove(id);
        }
    }
}
