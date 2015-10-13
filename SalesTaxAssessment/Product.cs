using System;

namespace SalesTaxAssessment
{
    public class Products : SalesTax
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsImport { get; set; }
        public bool IsTaxable { get; set; }
        public decimal SaleTax { get; set; }
        public decimal ImportationTax { get; set; }

        public Products(int quantity, string name, decimal price, bool isTaxable, bool isImport)
        {
            Quantity = quantity;
            Name = name;
            Price = price;
            IsTaxable = isTaxable;
            IsImport = isImport;
        }

        public decimal GetTax(object product)
        {
            return CalculateTax(Price);
        }

        public decimal ImportDutyTax(object product)
        {
            return CalculateImportDuty(Price);
        }
    }
}
