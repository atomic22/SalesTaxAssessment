using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxAssessment
{
    public class Invoice
    {
        public List<Products> Purchases = new List<Products>();
        public StringBuilder sr = new StringBuilder();
        public decimal SalesTaxTotal;
        public decimal InvoiceTotal;

        public void BuildInvoice(Products product)
        {
            Purchases.Add(product);
        }

        public string DisplayInovicedItems(List<Products> Purchases)
        {
            SalesTaxTotal = 0;
            InvoiceTotal = 0;

            foreach (var purchase in Purchases)
            {
                sr.Append(purchase.Name + " " + Math.Round(purchase.Price, 2) + "\n");
                SalesTaxTotal += purchase.SaleTax;
                InvoiceTotal += purchase.Price;
            }
            sr.Append("Sales Tax: " + Math.Round(SalesTaxTotal,2) + "\n");
            sr.Append("Total: " + Math.Round(InvoiceTotal, 2) + "\n");
            
            return sr.ToString();
        }




    }

}