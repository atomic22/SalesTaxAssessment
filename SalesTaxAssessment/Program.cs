using System;
using System.Collections.Generic;


namespace SalesTaxAssessment
{
    class Program : Invoice
    {
        static void Main(string[] args)
        {
            Invoice items = new Invoice();

            Products product = new Products("book", 12.49m, false, false);
            Products product1 = new Products("cd", 14.99m, true, false);
            Products product2 = new Products("chocolate", 0.85m, false, false);

            items.AddItemsToCart(product, 1);
            items.AddItemsToCart(product1, 1);
            items.AddItemsToCart(product2, 1);

            Console.WriteLine("Order 1:");
            Console.WriteLine(items.DisplayInovicedItems());
            ///////////////////////////////////////////////////////////////
            
            items = new Invoice();

            Products product3 = new Products("Imported Box of Chocolates", 10.00m, false, true);
            Products product4 = new Products("Imported bottle of Perfume", 47.50m, true, true);
            items.AddItemsToCart(product3, 1);
            items.AddItemsToCart(product4, 1);
            
            Console.WriteLine("Order 2:");
            Console.WriteLine(items.DisplayInovicedItems());
            ////////////////////////////////////////////////////////////////////

            items = new Invoice();
            
            Products product5 = new Products("Imported bottle of Perfume", 27.99m, false, false);
            Products product6 = new Products("Bottle of Perfume", 18.99m, false, false);
            Products product7 = new Products("Packet of Headache Pills", 9.75m, false, false);
            Products product8 = new Products("Imported Box of Chocolates", 11.25m, false, false);
            items.AddItemsToCart(product5, 1);
            items.AddItemsToCart(product6, 1);
            items.AddItemsToCart(product7, 1);
            items.AddItemsToCart(product8, 1);

            Console.WriteLine("Order 3:");
            Console.WriteLine(items.DisplayInovicedItems());
            /////////////////////////////////////////////////////////////////


            Console.Read();
        }



    }

}

