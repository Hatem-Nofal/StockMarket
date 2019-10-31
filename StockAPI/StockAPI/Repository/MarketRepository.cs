using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockAPI.API.Data;

namespace StockAPI.API.Models
{
    public class MarketRepository : IMarketRepository
    {
        private DataContext _context = new DataContext();
        private readonly ChangeStokePrice _changeStokePrice = new ChangeStokePrice();


        public async Task<List<Stock>> GetStocks()
        {
            return  await _changeStokePrice.changePrice();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

     
    }
}