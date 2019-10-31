using StockAPI.API.Models;
using Microsoft.EntityFrameworkCore;


namespace StockAPI.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(@"Data Source = C:\Work\TaskProject\StockAPI\StockAPI\ManageStocks.db; ");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(P => P.person).WithMany(o => o.Orders).IsRequired();
            modelBuilder.Entity<Order>().HasOne(s => s.stock).WithMany(o => o.Orders).IsRequired();


        }


    }
}