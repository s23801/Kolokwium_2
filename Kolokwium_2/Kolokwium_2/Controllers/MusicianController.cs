using Kolokwium_2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_2.Controllers
{
    [Route("api/musician")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly IDbService _dbService;
        MusicianController (IDbService dbService)
        {
            _dbService = dbService;
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveMusician(int id)
        {
            await _dbService.RemoveMusician(id);
            if(_dbService.RemoveMusician(id).IsCompletedSuccessfully)
            return Ok("Musician removed");
            else
                return BadRequest("Musician not removed");
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMusician(int id)
        {
            var musicians =  _dbService.GetMusician();
            return Ok(musicians);
        }
    }
}
