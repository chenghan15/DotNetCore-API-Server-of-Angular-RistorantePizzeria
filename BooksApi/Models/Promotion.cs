using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksApi.Models
{
    public class Promotion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string id { get; set; }

        public string name { get; set; }

        public string image { get; set; }

        public bool featured { get; set; }

        public string label { get; set; }

        public string description { get; set; }

        //public decimal price { get; set; }

        public string price { get; set; }
    }
}
