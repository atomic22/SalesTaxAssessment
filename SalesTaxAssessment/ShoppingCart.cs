using System;
using System.Collections.Generic;

namespace SalesTaxAssessment
{
    public class ShoppingCart: Products
    {
        public int Quantity { get; set; }
        List<Products> ProductsToBuy = new List<Products>();

        
        public void AddItemsToCart(List<Products> productstobuy, int quantity)
        {
            
            ProductsToBuy = productstobuy;
            Quantity = quantity;

        }
        
    }
}
