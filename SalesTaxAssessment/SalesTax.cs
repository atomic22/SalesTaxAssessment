using System;
namespace SalesTaxAssessment
{

    public abstract class SalesTax
    {
        const decimal TaxRate = .1m;
        const decimal ImportRate = .05m;

        public decimal Rate = TaxRate;
        public decimal ImportTax = ImportRate;



        //calculate the total tax
        public decimal CalculateTax(decimal price)
        {
            decimal st = price * Rate;
            st = Math.Ceiling(st * 20) / 20;
            return st;
        }

        //calculate the import duty
                public decimal CalculateImportDuty(decimal price)
        {
            decimal id = price * ImportTax;
            id = Math.Ceiling(id * 20) / 20;
            return id;
        }
    }
}
