using LearningMongodb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningMongodb.Repository;

namespace LearningMongodb.Services
{
    public class CharacterServices : ICharacterServices
    {
        private readonly ICharacterDAL _character;

        public CharacterServices(ICharacterDAL characterDAL)
        {
            _character = characterDAL;
        }

        public async Task<CharacterModel> Create(CharacterModel characterModel)
        {
            var character = characterModel;
            character.SysCode = Guid.NewGuid().ToString();
            await _character.Create(character);
            return await _character.GetOne(character.SysCode);
        }

        public async Task<List<CharacterModel>> GetData()
        {
            return await _character.GetData();
        }
    }
}
