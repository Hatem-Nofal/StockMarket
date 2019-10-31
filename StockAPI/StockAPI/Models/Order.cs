namespace StockAPI.API.Models
{
    public class Order {
        public int ID { get; set; }
        public int stockID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Commission { get; set; }
        public Person person { get; set; }
        public Stock stock { get; set; }


    }
}