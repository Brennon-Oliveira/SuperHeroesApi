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

        private void CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<ISuperHeroesRepository>(_superHeroesRepository.Object);

            ServiceLocator.SetProvider(services.BuildServiceProvider());
        }

        [TestMethod("Create should work returning the id")]
        public void CreateWorksTest()
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

            CreateServiceProvider();

            SuperHeroesActions superHeroesActions = new();

            int result = superHeroesActions.Create(createSuperHeroVO).Result;

            Assert.AreEqual(1, result);
        }

        [TestMethod("Create should throw ArgumentNullException when createSuperHeroVO is null")]
        public void CreateThrowsArgumentNullExceptionWhenCreateSuperHeroVOIsNullTest()
        {
            CreateSuperHeroVO createSuperHeroVO = null;
            createSuperHeroVO = new CreateSuperHeroVO
            {
                Name = "Teste",
                HeroName = "Teste",
                BirthDate = DateTime.Now,
                Height = 1,
                Weight = 1
            };

            CreateServiceProvider();

            SuperHeroesActions superHeroesActions = new();

            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => superHeroesActions.Create(createSuperHeroVO));

            createSuperHeroVO = new CreateSuperHeroVO
            {
                Name = "",
                HeroName = "Teste",
                BirthDate = DateTime.Now,
                Height = 1,
                Weight = 1
            };

            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => superHeroesActions.Create(createSuperHeroVO));

            createSuperHeroVO = new CreateSuperHeroVO
            {
                Name = "Teste",
                HeroName = "",
                BirthDate = DateTime.Now,
                Height = 1,
                Weight = 1
            };

            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => superHeroesActions.Create(createSuperHeroVO));
        }
    }
}