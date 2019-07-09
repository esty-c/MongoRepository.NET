using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Driver;
using MongoRepository.Infrastructure.Model;

namespace MongoRepository.Infrastructure.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        void Delete(Expression<Func<T, bool>> expression);

        void FindOneAndUpdate(Expression<Func<T, bool>> expression, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option);

        ReturnData UpdateOne(Expression<Func<T, bool>> expression, UpdateDefinition<T> update);

        void DeleteAll();

        T Single(Expression<Func<T, bool>> expression);

        IEnumerable<T> All();

        IEnumerable<T> All(int page, int pageSize);

        ReturnData Add(T item);

        void AddRange(IEnumerable<T> items);

        //void Add<T>(IEnumerable<T> items) where T : class, new();
    }
}