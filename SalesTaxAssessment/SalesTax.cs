namespace SalesTaxAssessment
{

    public abstract class SalesTax
    {
        private static readonly decimal TaxRate = .1m;
        private static readonly decimal ImportRate = .05m;

        public decimal Rate = TaxRate;
        public decimal ImportTax = ImportRate;
        
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
