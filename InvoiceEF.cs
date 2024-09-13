
using ConsoleApp8;
using Microsoft.EntityFrameworkCore;

namespace SQLite
{
    public class InvoiceEF : IDataHelper<Invoice>
    {
        private readonly DataBaseContext db;
        public InvoiceEF()
        {
            db = new DataBaseContext();
        }

        public int Add(Invoice invoice)
        {
            try
            {
                db.Items.AttachRange(invoice.Items);
                // Attach existing related entities (Products, Customers) if needed
                /*foreach (var product in invoice.Items)
                {
                    // Attach ensures EF Core knows the product is not new (if it exists)
                    db.Items.Attach(product);
                }*/
                // Add the new invoice
                db.Invoices.Add(invoice);

                // Save the changes, including many-to-many relationships
                db.SaveChanges();

                return 1;  // Success
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding invoice: {ex.Message}");
                return 0;  // Failure
            }
        }




        public int Delete(int Id)
        {
            try
            {
                var invoice = Find(Id);
                if (invoice != null)
                {
                    db.Invoices.Remove(invoice);
                    db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 0;
            }
        }

        public Invoice Find(int Id)
        {
            try
            {
                return db.Invoices.FirstOrDefault(x => x.Id == Id) ?? new Invoice();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new Invoice();
            }
        }

        public List<Invoice> GetAllData()
        {
            try
            {
                var studentsWithCourses = db.Invoices.Include(s => s.Items)  // Eagerly load related Courses
            .ToList();

                return studentsWithCourses;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Invoice>();
            }
        }

        public List<Invoice> Search(string searchItem)
        {
            try
            {
                return db.Invoices.Where(x => x.Id.ToString() == searchItem).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Invoice>();
            }
        }

        public int Update(Invoice entity)
        {
            try
            {
                db.Invoices.Update(entity);
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 0;
            }
        }
    }
}
