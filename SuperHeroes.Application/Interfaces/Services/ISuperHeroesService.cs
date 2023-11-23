using SuperHeroes.Application.Services;
using SuperHeroes.Application.ViewModels.SuperHeroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Application.Interfaces.Services
{
    public interface ISuperHeroesService
    {
        public Task<ServiceResponse<int>> Create(CreateSuperHeroViewModel createSuperHeroViewModel);
    }
}
