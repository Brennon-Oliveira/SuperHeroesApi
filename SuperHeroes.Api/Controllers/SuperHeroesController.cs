using SuperHeroes.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Infra.CrossCutting.ServiceLocator;
using SuperHeroes.Application.Interfaces.Services;
using SuperHeroes.Application.ViewModels.SuperHeroes;

namespace SuperHeroes.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class SuperHeroesController : ApiController
    {

        private readonly ISuperHeroesService _superHeroesService = ServiceLocator.GetService<ISuperHeroesService>();

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _superHeroesService.GetAll();
            return CustomResponse(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult> GetSearch([FromQuery] GetHeroesWithSearchViewModel getHeroesWithSearchViewModel)
        {
            var result = await _superHeroesService.GetSuperHeroesWithSearch(getHeroesWithSearchViewModel);
            return CustomResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _superHeroesService.GetById(id);
            return CustomResponse(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSuperHeroViewModel createSuperHeroViewModel)
        {
            var result = await _superHeroesService.Create(createSuperHeroViewModel);
            return CustomResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateSuperHeroViewModel updateSuperHeroViewModel)
        {
            var result = await _superHeroesService.Update(updateSuperHeroViewModel);
            return CustomResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _superHeroesService.Delete(id);
            return CustomResponse(result);
        }
    }
}
