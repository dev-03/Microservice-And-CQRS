using System;
using Microservice.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _db;

        public OrderRepository(OrderDbContext db)
        {
            _db = db;
        }

        public void Add(Order order)
        {
            _db.Order.Add(order);
        }

        public void Update(Order order)
        {
            _db.Order.Attach(order);
            _db.Entry(order).State = EntityState.Modified;
        }
    }
}