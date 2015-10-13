using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace SalesTaxAssessment
{
    class Program : Invoice
    {
        static void Main(string[] args)
        {
            List<object> carts = new List<object>();
            List<Products> cart1 = new List<Products>();
            Invoice items = new Invoice();

            cart1.Add(new Products(1, "book", 12.49m, false, false));
            cart1.Add(new Products(1, "music Cd", 14.99m, true, false));
            cart1.Add(new Products(1, "chocolate bar", 0.85m, false, false));

            carts.Add(cart1);


            foreach (var cart in carts)
            {
                foreach (var product in cart1)
                {
                    if (product.IsTaxable)
                    {
                        product.SaleTax = product.GetTax(cart1);
                        product.Price = product.Price + product.SaleTax;
                    }

                    if (product.IsImport)
                    {
                        product.SaleTax = product.ImportDutyTax(cart1);
                        product.Price = product.Price + product.ImportationTax;
                    }

                    items.BuildInvoice(product);
                }
            }



            Console.WriteLine(items.DisplayInovicedItems(items.Purchases));
            Console.Read();
        }



    }

}

