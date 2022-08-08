using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningMongodb.Models;

namespace LearningMongodb.Repository
{
    public interface ICharacterDAL
    {
        public Task<List<CharacterModel>> GetData();
        public Task Create(CharacterModel characterModel);
        public Task<CharacterModel> GetOne(string sysCode);
    }
}
