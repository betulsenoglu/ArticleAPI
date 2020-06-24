using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Database.Abstract;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Blog.Database.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IMongoCollection<T> _mongoCollection;

        public GenericRepository(IMongoDbSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.Database);
            _mongoCollection = db.GetCollection<T>(settings.Collection);
        }

        public async Task<bool> CreateAsync(T model)
        {
            try
            {
                await _mongoCollection.InsertOneAsync(model);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong: ", e);
                return false;
            }
        }

        public async Task<T> UpdateAsync(string id, T model)
        {
            var docId = new ObjectId(id);
            await _mongoCollection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", docId), model);
            return await GetByIdAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _mongoCollection.Find(x => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            try
            {
                var docId = new ObjectId(id);
                return await _mongoCollection.Find(Builders<T>.Filter.Eq("_id", docId)).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Someting went wrong: ", e);
                return null;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var docId = new ObjectId(id);
                await _mongoCollection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", docId));
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong", e);
            }
        }

        public void Delete(string id)
        {
            var docId = new ObjectId(id);
            _mongoCollection.DeleteOne(Builders<T>.Filter.Eq("_id", docId));
        }

        public T GetById(string id)
        {
            try
            {
                var docId = new ObjectId(id);
                return _mongoCollection.Find(Builders<T>.Filter.Eq("_id", docId)).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("Someting went wrong: ", e);
                return null;
            }
        }

        public void Update(string id, T model)
        {
            var docId = new ObjectId(id);
            _mongoCollection.ReplaceOne(Builders<T>.Filter.Eq("_id", docId), model);
        }

        public List<T> GetAll()
        {
            return _mongoCollection.Find(x => true).ToList();
        }
    }
}