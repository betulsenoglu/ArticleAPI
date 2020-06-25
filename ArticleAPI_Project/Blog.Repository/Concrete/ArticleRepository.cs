using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Database.Abstract;
using Blog.Database.Concrete;
using Blog.Domain.Entities.Enums;
using Blog.Domain.Entities.Models.Article;
using Blog.Repository.Abstract;
using MongoDB.Bson;
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
                                                                   (x.Text.ToLower().Contains(key.ToLower()) || x.Title.ToLower().Contains(key.ToLower()) ||
                                                                    x.Description.ToLower().Contains(key.ToLower())));
            }

            var results = cursor != null ? await cursor.ToListAsync() : null;
            return results;
        }


        public async Task<bool> DeleteViaUpdate(string id)
        {
            try
            {
                var filter = Builders<Article>.Filter.Eq("_Id", id);
                var update = Builders<Article>.Update.Set("Status", Status.Deleted).Set("UpdatedDate", DateTime.Now);
                await _mongoCollection.UpdateOneAsync(filter, update);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Someting went wrong: ", e);
                return false;
            }
        }
    }
}