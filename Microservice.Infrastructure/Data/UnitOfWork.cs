using System;
using System.Threading.Tasks;
using Microservice.Infrastructure.Models;

namespace Microservice.Infrastructure.Data.Repositories
{
    public class UnitOfWork
    {
        private readonly OrderDbContext _db;

        public UnitOfWork(OrderDbContext db)
        {
            _db = db;
        }

        public Task<int> SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
    }

}