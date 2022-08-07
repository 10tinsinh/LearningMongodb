using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningMongodb.Services;
using LearningMongodb.Models;

namespace LearningMongodb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly MongoDBService _mongDBService;
        public CharactersController(MongoDBService mongoDBService)
        {
            _mongDBService = mongoDBService;
        }
        [HttpGet]
        public async  Task<List<CharacterModel>> Get()
        {
            return await _mongDBService.Get();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CharacterModel characterModel)
        {
            await _mongDBService.Create(characterModel);
            return CreatedAtAction(nameof(Get), new { id = characterModel.Id }, characterModel);
        }

        
    }
}
