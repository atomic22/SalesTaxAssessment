using System;


namespace SalesTaxAssessment
{
    public class ShoppingCart: Products
    {
        public int Quantity { get; set; }

        public ShoppingCart(int quantity, string name, decimal price, bool isTaxable, bool isImport)
        {
            Quantity = quantity;
            Name = name;
            Price = price;
            IsTaxable = isTaxable;
            IsImport = isImport;
        }
    }
}
