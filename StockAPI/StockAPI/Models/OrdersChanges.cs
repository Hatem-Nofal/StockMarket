using StockAPI.API.Data;
using StockAPI.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Models
{
    public class OrdersChanges
    {
        private DataContext _context = new DataContext();
        public async Task< int> setorder()
        {
            var r = new Random();
            var stocks = _context.Stock.ToList();
            var persons = _context.Persons.ToList();
            int state = 0;
            for (int i = 1; i <= 10; i++)
            {
               
                var person = _context.Persons.Find(r.Next(1, persons.Count()+1));

                if (person.PersonType == "Client")
                {

                    int personnumber = _context.Persons.Count();
                    var stock = _context.Stock.Find(r.Next(1, stocks.Count()));
                    int stockid = stock.ID;
                    double stockprice = stock.Price;
                    int quantity = r.Next(1, 100);
                    double commission = (quantity * stockprice) * 2 / 100;

                    Order or = new Order
                    {
                        person = new Person { PersonID=person.PersonID },
                        Price = stockprice,
                        Quantity = quantity,
                        stockID = stockid,
                        Commission = commission
                    };
                    await _context.Orders.AddAsync(or);
                    state = await _context.SaveChangesAsync();


                }
                else if (person.PersonType == "Broker")
                {
                    int personnumber = _context.Persons.Count();
                    var stock = _context.Stock.Find(r.Next(1, stocks.Count()));
                    int stockid = stock.ID;
                    double stockprice = stock.Price;
                    int quantity = r.Next(1, 100);
                    double commission = (quantity * stockprice) * 1 / 100;
                    Order or = new Order
                    {
                        person = new Person { PersonID = person.PersonID },
                        Price = stockprice,
                        Quantity = quantity,
                        stockID = stockid,
                        Commission = commission
                    };
                    await _context.Orders.AddAsync(or);
                    state = await _context.SaveChangesAsync();
                }
            }
            return state;
        }


    }
}
