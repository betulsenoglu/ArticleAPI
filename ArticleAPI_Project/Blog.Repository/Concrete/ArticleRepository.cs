using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Database.Abstract;
using Blog.Database.Concrete;
using Blog.Domain.Entities.Models.Article;
using Blog.Repository.Abstract;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Blog.Repository.Concrete
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        private IMongoCollection<Article> _mongoCollection;

        public ArticleRepository(IMongoDbSettings settings) : base(settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.Database);
            _mongoCollection = db.GetCollection<Article>(settings.Collection);
        }

        public async Task<IList<Article>> SearchInArticlesAsync(string key)
        {
            IMongoQueryable<Article> cursor = null;
            if (!string.IsNullOrWhiteSpace(key))
            {
                cursor = _mongoCollection.AsQueryable().Where(x => x.Status == 0 &&
                                                                   (x.Text.Contains(key) || x.Title.Contains(key) ||
                                                                    x.Description.Contains(key)));
            }

            var results = cursor != null ? await cursor.ToListAsync() : null;
            return results;
        }
    }
}