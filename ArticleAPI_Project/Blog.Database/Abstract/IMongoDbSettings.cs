namespace Blog.Database.Abstract
{
    public interface IMongoDbSettings
    {
        string ConnectionString { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }
}