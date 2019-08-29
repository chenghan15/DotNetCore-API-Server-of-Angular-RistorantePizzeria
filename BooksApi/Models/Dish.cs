using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BooksApi.Models
{
    public class Dish
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string id { get; set; }

        public string name { get; set; }

        public string image { get; set; }

        public string category { get; set; }

        public bool featured { get; set; }

        public string label { get; set; }

        public string description { get; set; }

        public decimal price { get; set; }

        //public ICollection<Comments> comments { get; set; }
    }
}
