using System;

namespace SalesTaxAssessment
{
    public class Products : SalesTax
    {
        //basic info for products
        public string Name { get; set; }
        public decimal Price { get; set; }
        //booleans for taxation
        public bool IsImport { get; set; }
        public bool IsTaxable { get; set; }
        //Sales and Import tax properties
        public decimal SaleTax { get; set; }
        public decimal ImportationTax { get; set; }
        
        //Products constructor
        public Products(string name, decimal price, bool isTaxable, bool isImport)
        {
            this.Name = name;
            this.Price = price;
            this.IsTaxable = isTaxable;
            this.IsImport = isImport;
        }

        //get sales tax
        public decimal GetTax(object product)
        {
            return CalculateTax(Price);
        }

        //get import duty tax
        public decimal ImportDutyTax(object product)
        {
            return CalculateImportDuty(Price);
        }
    }
}
