using BooksApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BooksApi.Services
{
    public class PromotionService
    {
        private readonly IMongoCollection<Promotion> _promotions;

        public PromotionService(IConFusionDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _promotions = database.GetCollection<Promotion>(settings.promotionsCollectionName);
        }

        public List<Promotion> Get() =>
            _promotions.Find(promotion => true).ToList();

        public Promotion Get(string id) =>
            _promotions.Find<Promotion>(promotion => promotion.Id == id).FirstOrDefault();

        public List<Promotion> Get(bool featured) =>
            _promotions.Find(promotion => promotion.featured == featured).ToList();
        //_promotions.Find<Promotion>(promotion => promotion.featured == featured).FirstOrDefault();

        public Promotion Create(Promotion promotion)
        {
            _promotions.InsertOne(promotion);
            return promotion;
        }

        public void Update(string id, Promotion promotionIn) =>
            _promotions.ReplaceOne(promotion => promotion.Id == id, promotionIn);

        public void Remove(Promotion promotionIn) =>
            _promotions.DeleteOne(promotion => promotion.Id == promotionIn.Id);

        public void Remove(string id) =>
            _promotions.DeleteOne(promotion => promotion.Id == id);
    }
}