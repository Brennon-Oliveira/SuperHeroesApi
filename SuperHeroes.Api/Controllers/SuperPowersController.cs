using SuperHeroes.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Infra.CrossCutting.ServiceLocator;
using SuperHeroes.Application.Interfaces.Services;
using SuperHeroes.Application.ViewModels.SuperPowers;

namespace SuperHeroes.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class SuperPowersController : ApiController
    {

        private readonly ISuperPowersService _superPowersService = ServiceLocator.GetService<ISuperPowersService>();

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _superPowersService.GetAll();
            return CustomResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _superPowersService.GetById(id);
            return CustomResponse(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSuperPowerViewModel createSuperPowerViewModel)
        {
            var result = await _superPowersService.Create(createSuperPowerViewModel);
            return CustomResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateSuperPowerViewModel updateSuperPowerViewModel)
        {
            var result = await _superPowersService.Update(updateSuperPowerViewModel);
            return CustomResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _superPowersService.Delete(id);
            return CustomResponse(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult> GetSuperPowersWithSearch([FromQuery] GetSuperPowersWithSearchViewModel getSuperPowersWithSearchViewModel)
        {
            var result = await _superPowersService.GetSuperPowersWithSearch(getSuperPowersWithSearchViewModel);
            return CustomResponse(result);
        }

    }
}
