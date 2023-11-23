using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuperHeroes.Domain.Actions;
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

namespace SuperHeroes.Tests.Domain.Actions
{
    [TestClass()]
    public class SuperHeroesActionsTests
    {

        Mock<ISuperHeroesRepository> _superHeroesRepository = new Mock<ISuperHeroesRepository>();


        [TestInitialize()]
        public void Initialize()
        {
            _superHeroesRepository = new Mock<ISuperHeroesRepository>();

        }

        [TestMethod()]
        public void CreateTest()
        {

            CreateSuperHeroVO createSuperHeroVO = new()
            {
                Name = "Teste",
                HeroName = "Teste",
                BirthDate = DateTime.Now,
                Height = 1,
                Weight = 1
            };

            SuperHeroes.Domain.Models.SuperHeroes superHeroes = new()
            {
                Name = createSuperHeroVO.Name,
                HeroName = createSuperHeroVO.HeroName,
                BirthDate = createSuperHeroVO.BirthDate,
                Height = createSuperHeroVO.Height,
                Weight = createSuperHeroVO.Weight,
            };

            _superHeroesRepository.Setup(x => x.Add(It.Is<SuperHeroes.Domain.Models.SuperHeroes>(x =>
                x.Name == superHeroes.Name &&
                x.HeroName == superHeroes.HeroName &&
                x.BirthDate == superHeroes.BirthDate &&
                x.Height == superHeroes.Height &&
                x.Weight == superHeroes.Weight
            ))).ReturnsAsync(1);

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<ISuperHeroesRepository>(_superHeroesRepository.Object);

            ServiceLocator.SetProvider(services.BuildServiceProvider());

            SuperHeroesActions superHeroesActions = new();

            int result = superHeroesActions.Create(createSuperHeroVO).Result;

            Assert.AreEqual(1, result);
        }
    }
}