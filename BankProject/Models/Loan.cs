namespace BankProject.Models
{
    using System.Globalization;

    using BankProject.Core;
    using BankProject.Models.AccountTypes;

    public class Loan
    {
        public Loan(AccountType accountType, decimal drawnAmmount, int yearsToReturn)
        {
            this.DrawnAmount = drawnAmmount;
            this.InterestRate = CalculateInterestRate(accountType);
            this.YearsToReturn = yearsToReturn;
            this.NumberFormat = NumberFormatSingleton.NumberFormat;
        }

        public decimal DrawnAmount { get; set; }

        public decimal InterestRate { get; set; }

        public int YearsToReturn { get; set; }

        public decimal AmountToReturn => DrawnAmount * (1 + YearsToReturn * InterestRate); // Simple interest rate

        private NumberFormatInfo NumberFormat { get; init; }

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

        public override string ToString()
        {
            string loanString = string.Format(this.NumberFormat, "\tDrawn ammount: {0:C}", this.DrawnAmount) + Environment.NewLine +
                                $"\tInterest rate: {(int)(this.InterestRate * 100)}%" + Environment.NewLine +
                                $"\tYears to return: {this.YearsToReturn}" + Environment.NewLine +
                                string.Format(this.NumberFormat, "\tAmmount to return: {0:C}", this.AmountToReturn);

            return loanString;
        }
    }
}
