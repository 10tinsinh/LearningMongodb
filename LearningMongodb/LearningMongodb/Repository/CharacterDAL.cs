using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningMongodb.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LearningMongodb.Repository
{
    public class CharacterDAL:ICharacterDAL
    {
        private readonly IMongoCollection<CharacterModel> _historyCharacterCollection;
        public CharacterDAL(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _historyCharacterCollection = database.GetCollection<CharacterModel>(mongoDBSettings.Value.CollectionName);
        }

        public async Task Create(CharacterModel characterModel) =>
            await _historyCharacterCollection.InsertOneAsync(characterModel);


        public async Task<List<CharacterModel>> GetData() =>
            await _historyCharacterCollection.Find(_ => true).ToListAsync();

        public async Task<CharacterModel> GetOne(string sysCode) =>
            await _historyCharacterCollection.Find(e => e.SysCode == sysCode).FirstOrDefaultAsync();

        
    }
}
