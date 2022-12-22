using DDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Repository.OrderRepository
{
    internal interface IOrderRepository
    {
        Task<IOrder> GetOrder(int id);
        Task<IEnumerable<IOrder>> GetAllOrders();
        Task<IOrder> AddOrder(IOrder inputModel, OrderRoot orderRoot);
        Task<IOrder> UpdateOrder(int id, IOrder editModel);
        Task<IOrder> DeleteOrder(int id);
    }
}
