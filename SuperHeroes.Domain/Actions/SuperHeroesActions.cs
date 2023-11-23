
using SuperHeroes.Domain.Interfaces.Actions;
using SuperHeroes.Domain.Interfaces.Repositories;
using SuperHeroes.Domain.Models;
using SuperHeroes.Domain.VOs.SuperHeroes;
using SuperHeroes.Infra.CrossCutting.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Domain.Actions
{
    public class SuperHeroesActions : ISuperHeroesActions
    {
        private readonly ISuperHeroesRepository _superHeroesRepository = ServiceLocator.GetService<ISuperHeroesRepository>();
        public async Task<int> Create(CreateSuperHeroVO createSuperHeroVO)
        {
            if (createSuperHeroVO == null)
            {
                throw new ArgumentNullException("Dados precisam ser preenchidos");
            }
            if (string.IsNullOrWhiteSpace(createSuperHeroVO.Name))
            {
                throw new ArgumentNullException("Nome precisa ser preenchido");
            }
            if (string.IsNullOrWhiteSpace(createSuperHeroVO.HeroName))
            {
                throw new ArgumentNullException("Nome do herói precisa ser preenchido");
            }
            if (createSuperHeroVO.Height <= 0)
            {
                throw new ArgumentNullException("Altura precisa ser preenchida e positiva");
            }
            if (createSuperHeroVO.Weight <= 0)
            {
                throw new ArgumentNullException("Peso precisa ser preenchido e positivo");
            }

            int nameIsAvaliable = await _superHeroesRepository.NameIsAvaliable(createSuperHeroVO.Name, createSuperHeroVO.HeroName);

            if (nameIsAvaliable > 0)
            {
                throw new ArgumentException("Nome já está em uso");
            }

            Models.SuperHeroes superHero = new Models.SuperHeroes
            {
                Name = createSuperHeroVO.Name,
                HeroName = createSuperHeroVO.HeroName,
                BirthDate = createSuperHeroVO.BirthDate,
                Height = createSuperHeroVO.Height,
                Weight = createSuperHeroVO.Weight,
            };

            int id = await _superHeroesRepository.Add(superHero);
            return id;
        }

        public async Task<int> Update(UpdateSuperHeroVO updateSuperHeroVO)
        {
            if (updateSuperHeroVO == null)
            {
                throw new ArgumentNullException("Dados precisam ser preenchidos");
            }
            if (updateSuperHeroVO.Id <= 0)
            {
                throw new ArgumentNullException("Id precisa ser preenchido e positivo");
            }

            int exists = await _superHeroesRepository.Exists(updateSuperHeroVO.Id);
            if (exists <= 0)
            {
                throw new ArgumentException("Id não encontrado");
            }

            if(!string.IsNullOrWhiteSpace(updateSuperHeroVO.Name) && !string.IsNullOrWhiteSpace(updateSuperHeroVO.HeroName))
            {
                int nameIsAvaliable = await _superHeroesRepository.NameIsAvaliable(updateSuperHeroVO.Name, updateSuperHeroVO.HeroName);

                if (nameIsAvaliable > 0)
                {
                    throw new ArgumentException("Nome já está em uso");
                }
            }

            Models.SuperHeroes superHero = new Models.SuperHeroes()
            {
                Id = updateSuperHeroVO.Id,
            };

            if (!string.IsNullOrWhiteSpace(updateSuperHeroVO.Name))
            {
                superHero.Name = updateSuperHeroVO.Name;
            }

            if (!string.IsNullOrWhiteSpace(updateSuperHeroVO.HeroName))
            {
                superHero.HeroName = updateSuperHeroVO.HeroName;
            }

            if (updateSuperHeroVO.BirthDate.HasValue)
            {
                superHero.BirthDate = updateSuperHeroVO.BirthDate;
            }

            if (updateSuperHeroVO.Height.HasValue)
            {
                if (updateSuperHeroVO.Height <= 0)
                {
                    throw new ArgumentNullException("Altura precisa ser preenchida e positiva");
                }
                superHero.Height = updateSuperHeroVO.Height.Value;
            }

            if (updateSuperHeroVO.Weight.HasValue)
            {
                if (updateSuperHeroVO.Weight <= 0)
                {
                    throw new ArgumentNullException("Peso precisa ser preenchido e positivo");
                }
                superHero.Weight = updateSuperHeroVO.Weight.Value;
            }

            int id = await _superHeroesRepository.Update(superHero);
            return id;
        }

        public async void Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id precisa ser preenchido e positivo");
            }

            int exists = await _superHeroesRepository.Exists(id);
            if (exists < 0)
            {
                throw new ArgumentException("Nenhum herois encontrado para o id " + id);
            }

            _superHeroesRepository.Remove(id);
        }
    }
}
