
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace SQLite
{

    public class Program
    {
        static void Main(string[] args)
        {

            IDataHelper<Item> dataHelper = new ItemEF();
            IDataHelper<Invoice> invoiceDataHelper = new InvoiceEF();

            // Adding a new item

            //Console.WriteLine(dataHelper.Add(new Item { Id = 77, Name = "v7", initialPrice = 10, pricePrice = 17, wholesalePrice = 15, Quantity = 50 }));
            // Console.WriteLine(dataHelper.Add(new Item { Id = 44, Name = "V", initialPrice = 10, pricePrice = 17, wholesalePrice = 15, Quantity = 40 }));
            //Console.WriteLine(dataHelper.Add(new Item { Id = 55, Name = "I", initialPrice = 50, pricePrice = 60, wholesalePrice = 55, Quantity = 100 }));
            var items = dataHelper.GetAllData();
            foreach (var item in items)
            {
                Console.WriteLine($"Item ID: {item.Id}, Name: {item.Name},intialPrice:  {item.initialPrice}, picePrice: {item.pricePrice},wholesalePrice: {item.wholesalePrice},Quantity: {item.Quantity},{item}");
            }
            Console.WriteLine(invoiceDataHelper.Add(new Invoice
            {
                Id = 10111,
                Description = "I1",
                Items = items
                //     Items = items // Associate the items with the new invoice
            }));
            // Fetching all items
            var invoices = invoiceDataHelper.GetAllData();
            foreach (var invoice in invoices)
            {
               
              Console.WriteLine($"Item ID: {invoice.Id}, Description: {invoice.Description}");
                foreach (var item in invoice.Items)
                {
                    Console.WriteLine(item.Name);
                }
                /* foreach (var item in invoice.Items)
                  {
                      Console.WriteLine($"Item ID: {item.Id}, Name: {item.Name},intialPrice:  {item.initialPrice}, picePrice: {item.pricePrice},wholesalePrice: {item.wholesalePrice},Quantity: {item.Quantity}");
                  }
              }*/
            }
        }
    }
}
