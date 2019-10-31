using System.Collections.Generic;

namespace StockAPI.API.Models
{
    public class Person {
        public int PersonID { get; set; }
        public string PersonName { get; set; }
        public string PersonType { get; set; }
        public int? BrokerID { get; set; }
        public Person Broker { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}