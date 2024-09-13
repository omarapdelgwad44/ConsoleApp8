namespace SQLite

{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double initialPrice { get; set; }
        public double pricePrice { get; set; }
        public double wholesalePrice { get; set; }
        public int Quantity { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}