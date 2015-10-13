using System;

namespace SalesTaxAssessment
{
    public class Products : SalesTax
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public bool IsImport { get; set; }
        public bool IsTaxable { get; set; }

        public decimal SaleTax { get; set; }
        public decimal ImportationTax { get; set; }

        public Products(string name, decimal price, bool isTaxable, bool isImport)
        {
            this.Name = name;
            this.Price = price;
            this.IsTaxable = isTaxable;
            this.IsImport = isImport;
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
