using SuperHeroes.Application.Services;
using SuperHeroes.Application.ViewModels.SuperPowers;
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
    }
}
