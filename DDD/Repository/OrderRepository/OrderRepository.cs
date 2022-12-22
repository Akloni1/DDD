using DDD.Data;
using DDD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Repository.OrderRepository
{
    internal class OrderRepository
    {
        private readonly DDDContext _context;

        public OrderRepository(DDDContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrder(int id)
        {
            var Order = await _context.Orders.FirstOrDefaultAsync(m => m.IdOrder == id);
            return Order;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var Order = await _context.Orders.ToListAsync();
            return Order;
        }



        public async Task<Order> AddOrder(Order inputModel, OrderRoot orderRoot)
        {

            var orderRootAdded = _context.Add(orderRoot).Entity;
            await _context.SaveChangesAsync();
            inputModel.IdOrderRoot = orderRootAdded.IdOrderRoot;
            var orderAdded = _context.Add(inputModel).Entity;
            await _context.SaveChangesAsync();

            return orderAdded;

        }



        public async Task<Order> UpdateOrder(int id, Order editModel)
        {
            try
            {
                var Order = editModel;
                Order.IdOrder = id;

                _context.Update(Order);
                await _context.SaveChangesAsync();

                return Order;
            }
            catch (DbUpdateException)
            {
                if (!await OrderExists(id))
                {
                    return null;
                }
                else
                {
                    return null;
                }
            }
        }



        public async Task<Order> DeleteOrder(int id)
        {
            var Order = await _context.Orders.FindAsync(id);

            if (Order == null) return null;
            var OrderRoot = await _context.OrdersRoot.FindAsync(id);
            _context.OrdersRoot.Remove(OrderRoot);
            await _context.SaveChangesAsync();
            _context.Orders.Remove(Order);
            await _context.SaveChangesAsync();

            return Order;
        }


        private async Task<bool> OrderExists(int id)
        {
            return await _context.Orders.AnyAsync(e => e.IdOrder == id);
        }


    }
}
