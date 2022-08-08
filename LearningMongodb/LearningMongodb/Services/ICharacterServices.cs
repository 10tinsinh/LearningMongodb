using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningMongodb.Models;

namespace LearningMongodb.Services
{
    public interface ICharacterServices
    {
        public Task<List<CharacterModel>> GetData();
        public Task<CharacterModel> Create(CharacterModel characterModel);
        
    }
}
