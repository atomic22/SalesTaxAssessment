using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxAssessment
{
    class Program : Invoice
    {
        static void Main(string[] args)
        {
            Products[] products = new Products[3];
            Invoice items = new Invoice();


            products[0] = new Products()
            {
                Name = "book",
                Quantity = 1,
                Price = 12.49m,
                IsImport = false,
                IsTaxable = false
            };


            products[1] = new Products()
            {
                Name = "CD",
                 Quantity = 1,
                Price = 14.99m,
                IsImport = false,
                IsTaxable = true
            };

            products[2] = new Products()
            {
                Name = "Chocolate",
                Quantity = 1,
                Price = .85m,
                IsImport = false,
                IsTaxable = false
            };

            

            foreach (Products product in products)
            {
                if (product.IsTaxable)
                {
                    product.SaleTax = product.GetTax(product);
                    product.Price = product.Price + product.SaleTax;
                }

                if (product.IsImport)
                {
                    product.SaleTax = product.ImportDutyTax(product);
                    product.Price = product.Price + product.ImportationTax;
                }

                items.BuildInvoice(product);
                      
            }
            Console.WriteLine(items.DisplayInovicedItems(items.Purchases));
            Console.Read();
        }
        
    }
}
