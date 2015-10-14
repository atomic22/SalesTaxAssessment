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

        public Invoice() { }


        public void AddItemsToCart(Products item, int quantity)
        {
            Quantity = quantity;
            this._items.Add(item);

        }
        
        public string DisplayInovicedItems()
        {
            SalesTaxTotal = 0;
            InvoiceTotal = 0;

            foreach (var purchase in _items)
            {
                InvoicedSalesTax = 0m;
                InvoicedImportDuty = 0m;
                if (purchase.IsTaxable)
                {
                    InvoicedSalesTax = CalculateTax(purchase.Price);
                }

                if (purchase.IsImport)
                {
                    InvoicedImportDuty = CalculateImportDuty(purchase.Price);
                }

                purchase.Price = purchase.Price + InvoicedSalesTax;
                purchase.Price = purchase.Price + InvoicedImportDuty;

                sr.AppendLine(Quantity + " " + purchase.Name + " " + Math.Round(purchase.Price, 2));

                SalesTaxTotal += InvoicedSalesTax + InvoicedImportDuty;
                InvoiceTotal += purchase.Price;
            }
            sr.AppendFormat("Sales Tax : {0:N}", SalesTaxTotal);
            sr.AppendLine();
            sr.AppendLine("Total : " + Math.Round(InvoiceTotal, 2));

            return sr.ToString();
        }




    }

}