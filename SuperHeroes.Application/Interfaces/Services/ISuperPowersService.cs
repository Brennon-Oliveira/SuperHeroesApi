using SuperHeroes.Application.Services;
using SuperHeroes.Application.ViewModels.SuperPowers;
using SuperHeroes.Domain.Models;
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
        public Task<ServiceResponse<SuperPowers>> GetById(int id);
        public Task<ServiceResponse<List<SuperPowers>>> GetAll();
    }
}
