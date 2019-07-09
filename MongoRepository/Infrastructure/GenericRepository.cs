using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoRepository.Infrastructure.Interfaces;
using MongoRepository.Infrastructure.Model;
using MongoDB.Driver;

namespace MongoRepository.Infrastructure
{
    public class GenericRepository<T> : IRepository<T>
     where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            _unitOfWork.Db.GetCollection<T>(typeof(T).Name).DeleteOne(expression);
        }

        public void FindOneAndUpdate(Expression<Func<T, bool>> expression, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option)
        {
            var result= _unitOfWork.Db.GetCollection<T>(typeof(T).Name).FindOneAndUpdate(expression, update, option);
            
        }

        public ReturnData UpdateOne(Expression<Func<T, bool>> expression, UpdateDefinition<T> update)
        {
            var result = _unitOfWork.Db.GetCollection<T>(typeof(T).Name).UpdateOne(expression, update);

            if (result.MatchedCount > 0)
            {
                return new ReturnData(true, "Updated successfully");
            }

            return new ReturnData(false, "Updated failed");
        }

        public void DeleteAll()
        {
            _unitOfWork.Db.DropCollection(typeof(T).Name);
        }

        public T Single(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {


            return _unitOfWork.Db.GetCollection<T>(typeof(T).Name).AsQueryable().Where(expression).SingleOrDefault();
        }

        public IEnumerable<T> All()
        {
            return _unitOfWork.Db.GetCollection<T>(typeof(T).Name).AsQueryable().AsEnumerable().ToList();
        }

        public IEnumerable<T> All(int page, int pageSize)
        {
            return PagingExtensions.Page(_unitOfWork.Db.GetCollection<T>(typeof(T).Name).AsQueryable(), page, pageSize).AsEnumerable().ToList();
        }

        public ReturnData Add(T item)
        {
            try
            {
                _unitOfWork.Db.GetCollection<T>(typeof(T).Name).InsertOne(item);
                return new ReturnData(true, "successfully added");
            }
            catch (Exception ex)
            {
                return new ReturnData(false, ex.Message);
            }
        }

        public void AddRange(IEnumerable<T> items)
        {
            _unitOfWork.Db.GetCollection<T>(typeof(T).Name).InsertMany(items);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }


       
    }
}