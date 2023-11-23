using SuperHeroes.Application.Services;
using SuperHeroes.Application.ViewModels.SuperPowers;
using SuperHeroes.Domain.Models;
using SuperHeroes.Domain.VOs.Commons;
using SuperHeroes.Domain.VOs.SuperPowers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Application.Interfaces.Services
{
    public interface ISuperPowersService
    {
        public Task<ServiceResponse<int>> Create(CreateSuperPowerViewModel createSuperPowerViewModel);
        public Task<ServiceResponse<int>> Update(UpdateSuperPowerViewModel updateSuperPowerViewModel);
        public Task<ServiceResponse<int?>> Delete(int id);
        public Task<ServiceResponse<GetFullSuperPowerVO>> GetById(int id);
        public Task<ServiceResponse<List<GetFullSuperPowerVO>>> GetAll();
        public Task<ServiceResponse<PaginationResponseVO<GetFullSuperPowerVO>>> GetSuperPowersWithSearch(GetSuperPowersWithSearchViewModel getSuperPowersWithSearchViewModel);
    }
}
