using System;
namespace SalesTaxAssessment
{

    public abstract class SalesTax
    {
        const decimal TaxRate = .1m;
        const decimal ImportRate = .05m;

        public decimal Rate = TaxRate;
        public decimal ImportTax = ImportRate;


        private decimal roundTo;
                
        public decimal Round(decimal valToRound)
        {
            decimal remainder = Decimal.Remainder(valToRound, this.roundTo);
            if (remainder < (this.roundTo / 2))
                return valToRound - remainder;
            else
                return valToRound + (this.roundTo - remainder);
        }


        //calculate the total tax
        public decimal CalculateTax(decimal price)
        {

            return price * this.Rate;
        }

        //calculate the import duty
                public decimal CalculateImportDuty(decimal price)
        {
            return price * this.ImportTax;
        }
    }
}
