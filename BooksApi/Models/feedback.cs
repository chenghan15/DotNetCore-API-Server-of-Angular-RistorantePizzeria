using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksApi.Models
{
    public class feedback
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string id { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string telnum { get; set; }

        public string email { get; set; }

        public string agree { get; set; }

        public string contacttype { get; set; }

        public string message { get; set; }
    }
}
