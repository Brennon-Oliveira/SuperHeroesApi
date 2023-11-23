﻿using Castle.DynamicProxy.Generators;
using SuperHeroes.Domain.Interfaces.Actions;
using SuperHeroes.Domain.Interfaces.Repositories;
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
            if (createSuperHeroVO.Name == null)
            {
                throw new ArgumentNullException("Nome precisa ser preenchido");
            }
            if (createSuperHeroVO.HeroName == null)
            {
                throw new ArgumentNullException("Nome do herói precisa ser preenchido");
            }
            if (createSuperHeroVO.Height == 0)
            {
                throw new ArgumentNullException("Altura precisa ser preenchida");
            }
            if (createSuperHeroVO.Weight == 0)
            {
                throw new ArgumentNullException("Peso precisa ser preenchido");
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
    }
}