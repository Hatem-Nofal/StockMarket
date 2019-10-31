using System.Collections.Generic;

namespace StockAPI.API.Models
{
    public class Stock {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}