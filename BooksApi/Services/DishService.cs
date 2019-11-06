using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConFusionApi.Models;
using MongoDB.Driver;

namespace ConFusionApi.Services
{
    public class DishService
    {
        private readonly IMongoCollection<Dish> _dishes;

        public DishService(IConFusionDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _dishes = database.GetCollection<Dish>(settings.dishesCollectionName);
        }

        public List<Dish> Get() =>
            _dishes.Find(dish => true).ToList();

        public Dish Get(string id) =>
            _dishes.Find<Dish>(dish => dish.Id == id).FirstOrDefault();

        public Dish GetById(string id) =>
            _dishes.Find<Dish>(dish => dish.id == id).FirstOrDefault();

        public List<Dish> Get(bool featured) =>
            _dishes.Find(dish => dish.featured == featured).ToList();
        //_dishes.Find<Dish>(dish => dish.featured == featured).FirstOrDefault();

        public Dish Create(Dish dish)
        {
            _dishes.InsertOne(dish);
            return dish;
        }

        public void Update(string id, Dish dishIn) =>
            _dishes.ReplaceOne(dish => dish.Id == id, dishIn);

        public void Remove(Dish dishIn) =>
            _dishes.DeleteOne(dish => dish.Id == dishIn.Id);

        public void Remove(string id) =>
            _dishes.DeleteOne(dish => dish.Id == id);
    }
}
