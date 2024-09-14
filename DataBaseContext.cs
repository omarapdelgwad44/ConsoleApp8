using Microsoft.EntityFrameworkCore;
using SQLite;

public class DataBaseContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceItem> InvoiceItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=C:\Users\omara\source\repos\ConsoleApp8\SqliteDataBase.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure many-to-many relationship between Invoice and Item via InvoiceItem
        modelBuilder.Entity<InvoiceItem>()
            .HasKey(ii => new { ii.InvoiceId, ii.ItemId }); // Composite primary key

        modelBuilder.Entity<InvoiceItem>()
            .HasOne(ii => ii.Invoice)
            .WithMany(i => i.InvoiceItems)
            .HasForeignKey(ii => ii.InvoiceId);

        modelBuilder.Entity<InvoiceItem>()
            .HasOne(ii => ii.Item)
            .WithMany(i => i.InvoiceItems)
            .HasForeignKey(ii => ii.ItemId);
    }
}
