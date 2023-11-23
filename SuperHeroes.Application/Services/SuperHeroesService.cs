using SuperHeroes.Application.Interfaces.Services;
using SuperHeroes.Application.ViewModels.SuperHeroes;
using SuperHeroes.Application.ViewModels.SuperPowers;
using SuperHeroes.Domain.Actions;
using SuperHeroes.Domain.Interfaces.Actions;
using SuperHeroes.Domain.Interfaces.Repositories;
using SuperHeroes.Domain.Models;
using SuperHeroes.Domain.VOs.Commons;
using SuperHeroes.Domain.VOs.SuperHeroes;
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

        public async Task<ServiceResponse<int>> Update(UpdateSuperHeroViewModel updateSuperHeroViewModel)
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>()
            {
                StatusCode = HttpStatusCode.OK
            };
            try
            {
                int id = await _superHeroesActions.Update(updateSuperHeroViewModel.ToUpdateSuperHeroVO());
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
            ServiceResponse<int?> serviceResponse = new()
            {
                StatusCode = HttpStatusCode.OK
            };
            try
            {

                _superHeroesActions.Delete(id);
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

        public async Task<ServiceResponse<GetFullSuperHeroVO>> GetById(int id)
        {

            ServiceResponse<GetFullSuperHeroVO> serviceResponse = new()
            {
                StatusCode = HttpStatusCode.OK,
                Data = await _superHeroesRepository.GetFullHero(id)
            };
            if (serviceResponse.Data is null)
            {
                serviceResponse.StatusCode = HttpStatusCode.NotFound;
                serviceResponse.Errors.Add("Nenhum heroi encontrado para o id " + id);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetFullSuperHeroVO>>> GetAll()
        {
            ServiceResponse<List<GetFullSuperHeroVO>> serviceResponse = new()
            {
                StatusCode = HttpStatusCode.OK,
                Data = await _superHeroesRepository.GetAllFull()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<PaginationResponseVO<GetFullSuperHeroVO>>> GetSuperHeroesWithSearch(GetHeroesWithSearchViewModel getHeroesWithSearchViewModel)
        {
            ServiceResponse<PaginationResponseVO<GetFullSuperHeroVO>> serviceResponse = new()
            {
                StatusCode = HttpStatusCode.OK,
                Data = new PaginationResponseVO<GetFullSuperHeroVO>
                {
                    Page = getHeroesWithSearchViewModel.Page,
                    PageSize = getHeroesWithSearchViewModel.PageSize,
                    Total = await _superHeroesRepository.GetCount(),
                    Itens = await _superHeroesRepository.GetSuperHeroesWithSearch(getHeroesWithSearchViewModel.ToGetHeroesWithSearchVO())
                }
            };
            if (serviceResponse.Data.Itens.Count == 0 && !string.IsNullOrEmpty(getHeroesWithSearchViewModel.Search))
            {
                serviceResponse.StatusCode = HttpStatusCode.NotFound;
                serviceResponse.Errors.Add("Nenhum poder encontrado com os filtros informados");
            }
            return serviceResponse;
        }
    }
}
