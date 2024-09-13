using SQLite;

public class Invoice
{
    public int Id { get; set; }
    public string Description { get; set; }

    public ICollection<Item> Items { get; set; }
}