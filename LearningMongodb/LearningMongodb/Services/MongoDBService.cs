using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningMongodb.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace LearningMongodb.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<CharacterModel> _historyCharacterCollection;
        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _historyCharacterCollection = database.GetCollection<CharacterModel>(mongoDBSettings.Value.CollectionName);
        }
        public async Task Create(CharacterModel characterModel)
        {
            await _historyCharacterCollection.InsertOneAsync(characterModel);
            return;
        }
        public async Task<List<CharacterModel>> Get()
        {
            return await _historyCharacterCollection.Find(new BsonDocument()).ToListAsync();
        }


    }
}
