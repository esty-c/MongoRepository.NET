using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoRepository.Infrastructure.Model;
using MongoDB.Driver;

namespace MongoRepository.Infrastructure.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        void Delete(Expression<Func<T, bool>> expression);

        void FindOneAndUpdate(Expression<Func<T, bool>> expression, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option);

        ReturnData UpdateOne(Expression<Func<T, bool>> expression, UpdateDefinition<T> update);

        void DeleteAll();

        T Single(Expression<Func<T, bool>> expression);

        System.Linq.IQueryable<T> All<T>();

        System.Linq.IQueryable<T> All<T>(int page, int pageSize);

        ReturnData Add(T item);
        void AddRange(IEnumerable<T> items);
        //void Add<T>(IEnumerable<T> items) where T : class, new();
    }
}