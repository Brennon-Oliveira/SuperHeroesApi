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
            return Ok();
        }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult> GetSearch(string searchText, [FromQuery]int page, [FromQuery]int pageSize)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSuperHeroViewModel createSuperHeroViewModel)
        {
            var result = await _superHeroesService.Create(createSuperHeroViewModel);
            return CustomResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete()
        {
            return Ok();
        }
    }
}
