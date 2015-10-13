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

        public Invoice() { }


        public void AddItemsToCart(Products item, int quantity)
        {
            this._items.Add(item);

        }
        
        public string DisplayInovicedItems()
        {
            SalesTaxTotal = 0;
            InvoiceTotal = 0;

            foreach (var purchase in _items)
            {
                if (purchase.IsTaxable)
                {
                    purchase.SaleTax = CalculateTax(purchase.Price);

                }

                if (purchase.IsImport)
                {
                    purchase.ImportTax = CalculateImportDuty(purchase.Price);
                }

                purchase.Price = purchase.Price + purchase.SaleTax;
                purchase.Price = purchase.Price + purchase.ImportTax;

                sr.Append(purchase.Name + " " + Math.Round(purchase.Price, 2) + "\n");

                SalesTaxTotal += purchase.SaleTax + purchase.ImportTax;
                InvoiceTotal += purchase.Price;
            }
            sr.Append("Sales Tax: " + Math.Round(SalesTaxTotal, 2) + "\n");
            sr.Append("Total: " + Math.Round(InvoiceTotal, 2) + "\n");

            return sr.ToString();
        }




    }

}