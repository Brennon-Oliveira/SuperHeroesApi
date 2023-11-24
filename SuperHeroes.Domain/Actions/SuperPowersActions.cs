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
        private readonly ISuperHeroesRepository _superHeroesRepository = ServiceLocator.GetService<ISuperHeroesRepository>();
        public async Task<int> Create(CreateSuperPowerVO createSuperPowerVO)
        {
            if(createSuperPowerVO is null)
            {
                throw new ArgumentNullException(nameof(createSuperPowerVO));
            }

            if(string.IsNullOrWhiteSpace(createSuperPowerVO.Name))
            {
                throw new ArgumentException("Nome precisa ser preenchido");
            }

            SuperPowers superPower = new SuperPowers
            {
                Name = createSuperPowerVO.Name,
                Description = createSuperPowerVO.Description
            };

            int nameIsAvaliable = await _superPowersRepository.NameIsAvaliable(superPower.Name, -1);

            if(nameIsAvaliable > 0)
            {
                throw new ArgumentException("Nome já está em uso");
            }

            int id = await _superPowersRepository.Add(superPower);
            return id;
        }

        public async Task<int> Update(UpdateSuperHeroVO updateSuperPowerVO)
        {
            if (updateSuperPowerVO is null)
            {
                throw new ArgumentNullException(nameof(updateSuperPowerVO));
            }

            if(updateSuperPowerVO.Id <= 0)
            {
                throw new ArgumentException("Id precisa ser preenchido e positivo");
            }

            int exists = await _superPowersRepository.Exists(updateSuperPowerVO.Id);
            if (exists <= 0)
            {
                throw new ArgumentException("Nenhum poder encontrado para o id " + updateSuperPowerVO.Id);
            }

            int nameIsAvaliable = await _superPowersRepository.NameIsAvaliable(updateSuperPowerVO.Name, updateSuperPowerVO.Id);

            if (nameIsAvaliable > 0)
            {
                throw new ArgumentException("Nome já está em uso");
            }

            SuperPowers superPowers = new SuperPowers
            {
                Id = updateSuperPowerVO.Id,
            };

            if (!string.IsNullOrWhiteSpace(updateSuperPowerVO.Name))
            {
                superPowers.Name = updateSuperPowerVO.Name;
            }

            if(updateSuperPowerVO.Description != null)
            {
                superPowers.Description = updateSuperPowerVO.Description;
            }

            return await _superPowersRepository.Update(superPowers);
        }

        public async Task Delete(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException("Id precisa ser preenchido e positivo");
            }

            int exists = await _superPowersRepository.Exists(id);
            if (exists < 0)
            {
                   throw new ArgumentException("Nenhum poder encontrado para o id " + id);
            }

            var superHeroes = await _superHeroesRepository.GetHeroesByPower(id);
            if(superHeroes.Count > 0)
            {
                string error = "Não é possível excluir um poder que está sendo usado pelos herois:";
                foreach (var hero in superHeroes)
                {
                    error += "\n" + hero;
                }
                throw new ArgumentException(error);
            }

            await _superPowersRepository.Remove(id);
        }
    }
}
