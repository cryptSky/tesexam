using Data.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        IMongoCollection<TEntity> Collection { get; set; }

        Task<TEntity> GetByKey(object keyValue);
        IQueryable<TEntity> GetQuery();
        Task Add(TEntity entity);
        Task Remove(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<ReplaceOneResult> Save(TEntity doc);


    }
}
