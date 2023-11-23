using SuperHeroes.Application.Interfaces.Services;
using SuperHeroes.Application.ViewModels.SuperHeroes;
using SuperHeroes.Application.ViewModels.SuperPowers;
using SuperHeroes.Domain.Interfaces.Actions;
using SuperHeroes.Domain.Interfaces.Repositories;
using SuperHeroes.Domain.Models;
using SuperHeroes.Infra.CrossCutting.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Application.Services
{
    internal class SuperPowersService : ISuperPowersService
    {
        private readonly ISuperPowersActions _superPowersActions = ServiceLocator.GetService<ISuperPowersActions>();
        private readonly ISuperPowersRepository _superPowersRepository = ServiceLocator.GetService<ISuperPowersRepository>();

        public async Task<ServiceResponse<int>> Create(CreateSuperPowerViewModel createSuperPowerViewModel)
        {
            ServiceResponse<int> serviceResponse = new()
            {
                StatusCode = HttpStatusCode.Created
            };
            try
            {
                int id = await _superPowersActions.Create(createSuperPowerViewModel.ToCreateSuperPowerVO());
                serviceResponse.Data = id;
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ArgumentNullException) || ex.GetType() == typeof(ArgumentException))
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

        public async Task<ServiceResponse<int>> Update(UpdateSuperPowerViewModel updateSuperPowerViewModel)
        {
            ServiceResponse<int> serviceResponse = new()
            {
                StatusCode = HttpStatusCode.OK
            };
            try
            {
                int id = await _superPowersActions.Update(updateSuperPowerViewModel.ToUpdateSuperPowerVO());
                serviceResponse.Data = id;
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ArgumentNullException) || ex.GetType() == typeof(ArgumentException))
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

        public async Task<ServiceResponse<int?>> Delete(int id)
        {
            // EMPTY
            ServiceResponse<int?> serviceResponse = new()
            {
                StatusCode = HttpStatusCode.OK
            };
            try
            {
                _superPowersActions.Delete(id);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ArgumentNullException) || ex.GetType() == typeof(ArgumentException))
                {
                    serviceResponse.StatusCode = HttpStatusCode.BadRequest;
                } else
                {
                    serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
                }
                serviceResponse.Errors.Add(ex.Message);
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<SuperPowers>> GetById(int id)
        {

            SuperPowers? superPowers = await _superPowersRepository.GetById(id);
            ServiceResponse<SuperPowers> serviceResponse = new()
            {
                StatusCode = HttpStatusCode.OK,
                Data = await _superPowersRepository.GetById(id)
            };
            if (superPowers is null)
            {
                serviceResponse.StatusCode = HttpStatusCode.NotFound;
                serviceResponse.Errors.Add("Nenhum poder encontrado para o id " + id);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<SuperPowers>>> GetAll()
        {
            ServiceResponse<List<SuperPowers>> serviceResponse = new()
            {
                StatusCode = HttpStatusCode.OK,
                Data = await _superPowersRepository.GetAll()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<SuperPowers>>> GetSuperPowersWithSearch(GetSuperPowersWithSearchViewModel getSuperPowersWithSearchViewModel)
        {
            ServiceResponse<List<SuperPowers>> serviceResponse = new()
            {
                StatusCode = HttpStatusCode.OK,
                Data = await _superPowersRepository.GetSuperPowersWithSearch(getSuperPowersWithSearchViewModel.ToGetSuperPowersWithSearchVO())
            };
            if(serviceResponse.Data.Count == 0 && !string.IsNullOrEmpty(getSuperPowersWithSearchViewModel.Search))
            {
                serviceResponse.StatusCode = HttpStatusCode.NotFound;
                serviceResponse.Errors.Add("Nenhum poder encontrado com os filtros informados");
            }
            return serviceResponse;
        }
    }
}
