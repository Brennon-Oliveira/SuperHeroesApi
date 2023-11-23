using SuperHeroes.Application.Services;
using SuperHeroes.Application.ViewModels.SuperHeroes;
using SuperHeroes.Domain.VOs.Commons;
using SuperHeroes.Domain.VOs.SuperHeroes;
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
        public Task<ServiceResponse<int>> Update(UpdateSuperHeroViewModel updateSuperHeroViewModel);
        public Task<ServiceResponse<int?>> Delete(int id);
        Task<ServiceResponse<GetFullSuperHeroVO>> GetById(int id);
        Task<ServiceResponse<List<GetFullSuperHeroVO>>> GetAll();
        Task<ServiceResponse<PaginationResponseVO<GetFullSuperHeroVO>>> GetSuperHeroesWithSearch(GetHeroesWithSearchViewModel getHeroesWithSearchViewModel);
    }
}
