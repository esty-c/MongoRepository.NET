using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoRepository.Infrastructure.Configuration;
using MongoRepository.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace MongoRepository.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly Context db;
       // private static IMongoClient server;

    
//public MongoDB.Driver.IMongoDatabase database;

        public UnitOfWork()
        {
         
         //  database= new Context().database;
        }

        public void Dispose()
        {
            //db.Dispose();
            // database.dis
        }

   

        public IMongoDatabase Db
        {
            get { return new Context().database; }
        }
    }
}
