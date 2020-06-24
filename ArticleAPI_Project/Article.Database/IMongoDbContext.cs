using MongoDB.Driver;

namespace Article.Database
{
    public interface IMongoDbContext
    {
        public class MongoBookDBContext : IMongoBookDBContext
        {

            public TYPE Type { get; set; }
            public IMongoCollection<T> GetCollection<T>(string name)
            {
                GetCollection<T>(); Setting<;>
            }
        }
    }
}