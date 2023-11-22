using SuperHeroes.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroes.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class SuperPowersController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok();
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
