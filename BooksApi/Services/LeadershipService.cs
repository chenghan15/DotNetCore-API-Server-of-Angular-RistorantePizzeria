using BooksApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BooksApi.Services
{
    public class LeadershipService
    {
        private readonly IMongoCollection<Leadership> _leaderships;

        public LeadershipService(IConFusionDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _leaderships = database.GetCollection<Leadership>(settings.leadershipCollectionName);
        }

        public List<Leadership> Get() =>
            _leaderships.Find(leadership => true).ToList();

        public Leadership Get(string id) =>
            _leaderships.Find<Leadership>(leadership => leadership.Id == id).FirstOrDefault();

        public Leadership Create(Leadership leadership)
        {
            _leaderships.InsertOne(leadership);
            return leadership;
        }

        public void Update(string id, Leadership leadershipIn) =>
            _leaderships.ReplaceOne(leadership => leadership.Id == id, leadershipIn);

        public void Remove(Leadership leadershipIn) =>
            _leaderships.DeleteOne(leadership => leadership.Id == leadershipIn.Id);

        public void Remove(string id) =>
            _leaderships.DeleteOne(leadership => leadership.Id == id);
    }
}