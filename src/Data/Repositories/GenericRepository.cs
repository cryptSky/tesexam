using Data.Entities;
using Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tesexam.Data.Infrastructure;

namespace Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity, new()
    {
        private IMongoDbContext _context;
        public IMongoCollection<TEntity> Collection { get; set; }

        public GenericRepository(IMongoDbContext context)
        {
            _context = context;

            // exclude DO from name of the collection
            var entityName = typeof(TEntity).Name;
            var collectionName = entityName.Substring(entityName.Length - 2).ToLower();

            Collection = _context.Database.GetCollection<TEntity>(collectionName);
        }       

        public async Task<TEntity> GetByKey(object keyValue)
        {
            var id = (ObjectId)keyValue;
            var filter = Builders<TEntity>.Filter.Eq(q => q.Id, id);
            var result = await Collection.Find(filter).SingleAsync();

            return result;
        }

        public IQueryable<TEntity> GetQuery()
        {
            return Collection.AsQueryable();
        }

        public async Task Add(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
        }

        public async Task Remove(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq(q => q.Id, entity.Id);
            var result = await Collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Collection.Find(_ => true).ToListAsync();
        }

        public async Task<ReplaceOneResult> Save(TEntity doc)
        {
            return await Collection.ReplaceOneAsync(w => w.Id.Equals(doc.Id), doc, new UpdateOptions { IsUpsert = true });
        }
    }
}

