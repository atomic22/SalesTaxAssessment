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

            Products products = new Products();
            Invoice items = new Invoice();
          
            using (StreamReader sr = File.OpenText("ShoppingBasket.txt"))
                //stuck here
                while (sr.Peek() >= 0)
                {
                    Regex
        .Matches(sr.ReadLine(), @"(?<match>\w+)|\""(?<match>[\w\s]*)""")
        .Cast<Match>()
        .Select(m => m.Groups["match"].Value)
        .ToList()
        .ForEach(s => products.Name = s.ToString());

                    //= sr.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);



                    
                    //products.Price = Convert.ToDecimal(shoppingBasketContent[3].ToString());
                    //products.IsImport = Convert.ToBoolean(shoppingBasketContent[4]);
                    //products.IsTaxable = Convert.ToBoolean(shoppingBasketContent[5]);

                    if (products.IsTaxable)
                    {
                        products.SaleTax = products.GetTax(products);
                        products.Price = products.Price + products.SaleTax;
                    }

                    if (products.IsImport)
                    {
                        products.SaleTax = products.ImportDutyTax(products);
                        products.Price = products.Price + products.ImportationTax;
                    }

                    items.BuildInvoice(products);


                }

            Console.WriteLine(items.DisplayInovicedItems(items.Purchases));
            Console.Read();
        }

    }
}
