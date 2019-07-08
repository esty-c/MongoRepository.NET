using MongoRepository.Infrastructure;
using MongoRepository.Infrastructure.Interfaces;
using MongoRepository.Models;

namespace MongoRepository.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        private IUnitOfWork unit;

        public UserRepository(IUnitOfWork unit)
            : base(unit)
        {
            this.unit = unit;
        }
    }
}