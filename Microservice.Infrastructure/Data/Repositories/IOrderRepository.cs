using System;
using Microservice.Infrastructure.Models;

namespace Microservice.Infrastructure.Data.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void Update(Order order);
    }

}