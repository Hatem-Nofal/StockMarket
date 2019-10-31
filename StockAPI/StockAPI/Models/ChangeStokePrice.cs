using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockAPI.API.Data;

namespace StockAPI.API.Models
{
    public class ChangeStokePrice
    {
        private DataContext _context = new DataContext();
        public ChangeStokePrice()
        {

        }
        public async Task<List<Stock>> changePrice()
        {
            var r = new Random();
            var stocks = _context.Stock.ToList();
            for (int i = 1; i <= stocks.Count; i++)
            {

                var stockprice = _context.Stock.Find(i);
                if (stockprice.Price > 50)
                {
                    stockprice.Price = stockprice.Price - r.Next(1, 50);
                }
                else if (stockprice.Price <= 50)
                {
                    stockprice.Price = stockprice.Price + r.Next(1, 50);
                }

            }
            await _context.SaveChangesAsync();
            var stock = await _context.Stock.ToListAsync();
            return stock;


        }
    }
}