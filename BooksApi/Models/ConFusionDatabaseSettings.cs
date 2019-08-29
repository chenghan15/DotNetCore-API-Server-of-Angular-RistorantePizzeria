namespace BooksApi.Models
{
    public class ConFusionDatabaseSettings : IConFusionDatabaseSettings
    {
        public string dishesCollectionName { get; set; }
        public string promotionsCollectionName { get; set; }
        public string leadershipCollectionName { get; set; }
        public string feedbackCollectionName { get; set; }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IConFusionDatabaseSettings
    {
        string dishesCollectionName { get; set; }
        string promotionsCollectionName { get; set; }
        string leadershipCollectionName { get; set; }
        string feedbackCollectionName { get; set; }

        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}