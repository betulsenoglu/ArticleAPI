using Blog.Database.Abstract;

namespace Blog.Database.Concrete
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
    }
}