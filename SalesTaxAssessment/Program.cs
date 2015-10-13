using System;
using System.Collections.Generic;
 

namespace SalesTaxAssessment
{
    class Program : Invoice
    {
        static void Main(string[] args)
        {
            List<object> AllCarts = new List<object>();
            List<object> cart1 = new List<object>();
            List<object> cart2 = new List<object>();
            List<object> cart3 = new List<object>();

            Invoice items = new Invoice();

            //items collected
            ShoppingCart ItemsInCart0 = new ShoppingCart(1, "nb", 12.49m, false, false);
            ShoppingCart ItemsInCart1 = new ShoppingCart(1, "cd", 14.99m, true, false);
            ShoppingCart ItemsInCart2 = new ShoppingCart(1, "cb", 0.85m, false, false);

            //items placed inside cart
            cart1.Add(ItemsInCart0);
            cart1.Add(ItemsInCart1);
            cart1.Add(ItemsInCart2);

            //add cart to collection of carts
            AllCarts.Add(cart1);


            //loop over each cart
            foreach (var cart in AllCarts)
            {



                if (ItemsInCart0.IsTaxable)
                {
                    ItemsInCart0.SaleTax = ItemsInCart0.GetTax(cart);
                    ItemsInCart0.Price = ItemsInCart0.Price + ItemsInCart0.SaleTax;
                }
                if (ItemsInCart0.IsImport)
                {
                    ItemsInCart0.SaleTax = ItemsInCart0.ImportDutyTax(cart);
                    ItemsInCart0.Price = ItemsInCart0.Price + ItemsInCart0.ImportationTax;
                }

                items.BuildInvoice(ItemsInCart0);
            }



            Console.WriteLine(items.DisplayInovicedItems(items.Purchases));
            Console.Read();
        }



    }

}

