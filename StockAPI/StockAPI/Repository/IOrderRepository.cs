using StockAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAPI.Repository
{
    public interface IOrderRepository
    {
        Task<int> Add();
        Task<List<OrderUIData>> getOrders();
       
       
    }
}
