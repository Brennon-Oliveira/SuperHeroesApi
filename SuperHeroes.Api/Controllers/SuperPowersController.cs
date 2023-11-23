using SuperHeroes.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Infra.CrossCutting.ServiceLocator;
using SuperHeroes.Application.Interfaces.Services;

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
            var result = _superPowersService.GetAll();
            return CustomResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Create()
        {
            return Ok();
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
