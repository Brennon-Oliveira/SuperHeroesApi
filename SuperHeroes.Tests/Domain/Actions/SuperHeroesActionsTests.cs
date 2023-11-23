using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuperHeroes.Domain.Actions;
using SuperHeroes.Domain.Interfaces.Actions;
using SuperHeroes.Domain.Interfaces.Repositories;
using SuperHeroes.Domain.Models;
using SuperHeroes.Domain.VOs.SuperHeroes;
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
                Name = "Teste",
                HeroName = "Teste",
                BirthDate = DateTime.Now,
                Height = 1,
                Weight = 1
            };

            _superHeroesRepository.Setup(x => x.Add(It.Equals(superHeroes))).ReturnsAsync(1);



            SuperHeroesActions superHeroesActions = new();

        }
    }
}