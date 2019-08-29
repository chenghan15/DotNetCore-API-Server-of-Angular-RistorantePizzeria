using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksApi.Models
{
    public class Leadership
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string id { get; set; }

        public string name { get; set; }

        public string image { get; set; }

        public bool featured { get; set; }

        public string abbr { get; set; }

        public string description { get; set; }

        public string designation { get; set; }
    }
}
