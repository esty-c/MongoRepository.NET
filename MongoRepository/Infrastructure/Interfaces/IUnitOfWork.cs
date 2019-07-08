using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoRepository.Infrastructure.Configuration;
using MongoDB.Driver;

namespace MongoRepository.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// </summary>
        IMongoDatabase Db { get; }


    }
}
