using System.Threading.Tasks;
using System.Collections.Generic;
using StockAPI.API.Models;

namespace StockAPI.API.Models
{
    public interface IMarketRepository
    {
     
        Task<bool> SaveAll ();
        Task<List<Stock>> GetStocks ();
    }
}