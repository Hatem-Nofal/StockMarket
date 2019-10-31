using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockAPI.API.Data;
using StockAPI.Models;

namespace StockAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersChanges _ordersChanges = new OrdersChanges();
        private DataContext _context = new DataContext();


        public async Task<int> Add()
        {

            return await _ordersChanges.setorder();
        }

        public async Task<List<OrderUIData>> getOrders()
        {
            var orders = await (from order in _context.Orders
                                join stocks in _context.Stock
                                on order.stockID equals stocks.ID
                                join person in _context.Persons
                                on order.person.PersonID equals person.PersonID
                                select new OrderUIData
                                {
                                    PersonName = person.PersonName,
                                    Name = stocks.Name,
                                    Price = order.Price,
                                    Quantity = order.Quantity,
                                    Commission = order.Commission
                                }).ToListAsync();

            return orders;
        }

      
    }
}
