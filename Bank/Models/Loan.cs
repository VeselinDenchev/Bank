namespace EvilBank.Models
{
    using EvilBank.Models.AccountTypes;

    public class Loan
    {
        public Loan(AccountType accountType, decimal drawnAmmount, int yearsToReturn)
        {
            this.DrawnAmmount = drawnAmmount;
            this.InterestRate = CalculateInterestRate(accountType);
            Console.WriteLine(accountType.GetType().Name);
            this.YearsToReturn = yearsToReturn;
        }

        public decimal DrawnAmmount { get; set; }

        public decimal InterestRate { get; set; }

        public int YearsToReturn { get; set; }

        public decimal AmmountToReturn => this.DrawnAmmount * (1 + this.YearsToReturn * this.InterestRate); // Simple interest rate

        private decimal CalculateInterestRate(AccountType accountType)
        {
            decimal interestRate = 0;

            switch (accountType.GetType().Name)
            {
                case "Regular":
                    interestRate = 0.6m;
                    break;

                case "Bronze":
                    interestRate = 0.5m;
                    break;

                case "Gold":
                    interestRate = 0.3m;
                    break;

                case "Platinum":
                    interestRate = 0.01m;
                    break;
            }

            return interestRate;
        }
    }
}
