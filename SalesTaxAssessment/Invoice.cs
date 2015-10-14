using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace SalesTaxAssessment
{
    public class Invoice : SalesTax
    {
        
        public Collection<Products> _items = new Collection<Products>();
        public int Quantity { get; set; }
        public List<Products> Purchases = new List<Products>();
        public StringBuilder sr = new StringBuilder();
        public decimal SalesTaxTotal;
        public decimal InvoiceTotal;
        public decimal InvoicedSalesTax;
        public decimal InvoicedImportDuty;

        //constructor
        public Invoice() { }

        //add the items to the cart
        public void AddItemsToCart(Products item, int quantity)
        {
            Quantity = quantity;
            this._items.Add(item);
        }

        //build the display to output to the user
        public string DisplayInovicedItems()
        {
            SalesTaxTotal = 0;
            InvoiceTotal = 0;
            //loop through each item in our shopping cart
            foreach (var purchase in _items)
            {
                //reset tax values
                InvoicedSalesTax = 0m;
                InvoicedImportDuty = 0m;

                //check if the product taxable if it is then calculate the sales tax
                if (purchase.IsTaxable)
                {
                    InvoicedSalesTax = CalculateTax(purchase.Price);
                }

                //check if the product is imported, if so then add the import duty
                if (purchase.IsImport)
                {
                    InvoicedImportDuty = CalculateImportDuty(purchase.Price);
                }

                //add the sales tax and import duty to the price of the product
                purchase.Price = purchase.Price + InvoicedSalesTax;
                purchase.Price = purchase.Price + InvoicedImportDuty;

                //place the basic information for the product into the stringbuilder
                sr.AppendLine(Quantity + " " + purchase.Name + " " + Math.Round(purchase.Price, 2));

                //keep a running total for the cart of taxes
                SalesTaxTotal += InvoicedSalesTax + InvoicedImportDuty;
                InvoiceTotal += purchase.Price;
            }
            //append the sales tax with the proper formatting
            sr.AppendFormat("Sales Tax : {0:N}", SalesTaxTotal);
            //place an new line in the stringbuilder
            sr.AppendLine();
            //add our final total to the stringbuilder
            sr.AppendLine("Total : " + Math.Round(InvoiceTotal, 2));

            //return the stringbuilder for display and possibly a cringe
            return sr.ToString();
        }

    }

}