using BooksApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BooksApi.Services
{
    public class FeedbackService
    {
        private readonly IMongoCollection<Feedback> _feedbacks;

        public FeedbackService(IConFusionDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _feedbacks = database.GetCollection<Feedback>(settings.feedbackCollectionName);
        }

        public List<Feedback> Get() =>
            _feedbacks.Find(feedback => true).ToList();

        public Feedback Get(string id) =>
            _feedbacks.Find<Feedback>(feedback => feedback.Id == id).FirstOrDefault();

        public Feedback Create(Feedback feedback)
        {
            _feedbacks.InsertOne(feedback);
            return feedback;
        }

        public void Update(string id, Feedback feedbackIn) =>
            _feedbacks.ReplaceOne(feedback => feedback.Id == id, feedbackIn);

        public void Remove(Feedback feedbackIn) =>
            _feedbacks.DeleteOne(feedback => feedback.Id == feedbackIn.Id);

        public void Remove(string id) =>
            _feedbacks.DeleteOne(feedback => feedback.Id == id);
    }
}