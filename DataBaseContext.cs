
using Microsoft.EntityFrameworkCore;

namespace SQLite
{
    public class DataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\omara\source\repos\ConsoleApp8\SqliteDataBase.db");
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }

}
