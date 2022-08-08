using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningMongodb.Services;
using LearningMongodb.Models;

namespace LearningMongodb.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ICharacterServices _character;

        public CharacterController(ICharacterServices characterServices)
        {
            _character = characterServices;
        }

        [HttpGet("Get")]
        public async Task<List<CharacterModel>> GetCharacter()
        {
            return await _character.GetData();
        }
        [HttpPost("Create")]
        public async Task<CharacterModel> CreateCharacter(CharacterModel characterModel)
        {
            return await _character.Create(characterModel);
        }
    }
}
