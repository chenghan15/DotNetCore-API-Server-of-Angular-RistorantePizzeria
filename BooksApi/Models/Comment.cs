using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConFusionApi.Models
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string dish { get; set; }

        public double rating { get; set; }

        public string comment { get; set; }

        public string author { get; set; }

        public string date { get; set; }
    }
}
