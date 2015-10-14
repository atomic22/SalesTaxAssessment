using System;
namespace SalesTaxAssessment
{

    public abstract class SalesTax
    {
        //set the tax and import rates as constants
        const decimal TaxRate = .1m;
        const decimal ImportRate = .05m;

        //make them available
        public decimal Rate = TaxRate;
        public decimal ImportTax = ImportRate;



        //calculate the total tax
        public decimal CalculateTax(decimal price)
        {
            //make sure the rounding is correct
            decimal st = price * Rate;
            st = Math.Ceiling(st * 20) / 20;
            return st;
        }

        //calculate the import duty
        public decimal CalculateImportDuty(decimal price)
        {
            //again watch the rounding don't want to pay to little or too much
            decimal id = price * ImportTax;
            id = Math.Ceiling(id * 20) / 20;
            return id;
        }
    }
}
