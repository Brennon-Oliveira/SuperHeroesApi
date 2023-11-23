using SuperHeroes.Application.Interfaces.Services;
using SuperHeroes.Application.ViewModels.SuperHeroes;
using SuperHeroes.Domain.Interfaces.Actions;
using SuperHeroes.Domain.Interfaces.Repositories;
using SuperHeroes.Infra.CrossCutting.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Application.Services
{
    internal class SuperHeroesService : ISuperHeroesService
    {
        private readonly ISuperHeroesRepository _superHeroesRepository = ServiceLocator.GetService<ISuperHeroesRepository>();
        private readonly ISuperHeroesActions _superHeroesActions = ServiceLocator.GetService<ISuperHeroesActions>();
        public async Task<ServiceResponse<int>> Create(CreateSuperHeroViewModel createSuperHeroViewModel)
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>()
            {
                StatusCode = HttpStatusCode.Created
            };
            try
            {
                int id = await _superHeroesActions.Create(createSuperHeroViewModel.ToCreateSuperHeroVO());
                serviceResponse.Data = id;
            } catch (Exception ex)
            {
                if (ex.GetType() == typeof(ArgumentNullException))
                {
                    serviceResponse.StatusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
                }
                serviceResponse.Errors.Add(ex.Message);
            }

            return serviceResponse;
        }
    }
}
