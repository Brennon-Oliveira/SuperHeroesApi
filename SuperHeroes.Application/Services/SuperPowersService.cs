using SuperHeroes.Application.Interfaces.Services;
using SuperHeroes.Application.ViewModels.SuperPowers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Application.Services
{
    internal class SuperPowersService : ISuperPowersService
    {
        public Task<ServiceResponse<int>> Create(CreateSuperPowerViewModel createSuperPowerViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
