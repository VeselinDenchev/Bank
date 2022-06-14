namespace BankProject.Models
{
    using System.Globalization;

    using BankProject.Constants;
    using BankProject.Models.AccountTypes;
    using BankProject.Models.Interfaces;
    using BankProject.Singleton;

    public class Loan : ILoan
    {
        public Loan(decimal drawnAmmount, AccountType accountType, byte yearsToReturn)
        {
            this.Id = Guid.NewGuid().ToString();
            this.DrawnAmount = drawnAmmount;
            this.InterestRate = CalculateInterestRate(accountType);
            this.YearsToReturn = yearsToReturn;
            this.NumberFormat = NumberFormatSingleton.Instance;
        }

        public Loan(string id, decimal drawnAmmount, decimal interestRate, byte yearsToReturn)
        {
            this.Id = id;
            this.DrawnAmount = drawnAmmount;
            this.InterestRate = interestRate;
            this.YearsToReturn = yearsToReturn;
            this.NumberFormat = NumberFormatSingleton.Instance;
        }

        public string Id { get; init; }

        public decimal DrawnAmount { get; init; }

        public decimal InterestRate { get; init; }

        public byte YearsToReturn { get; init; }

        public decimal AmountToReturn => DrawnAmount * (1 + YearsToReturn * InterestRate); // Simple interest rate

        private NumberFormatInfo NumberFormat { get; init; }

        protected decimal CalculateInterestRate(AccountType accountType)
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
            string loanString = string.Format(this.NumberFormat, StringConstant.LOAN_STRING, this.Id, this.DrawnAmount, (int)(this.InterestRate * 100),
                                                this.Id, this.YearsToReturn, this.AmountToReturn);

            return loanString;
        }
    }
}
