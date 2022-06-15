namespace BankProject.Models
{
    using System.Globalization;

    using BankProject.Constants;
    using BankProject.Models.AccountTypes;
    using BankProject.Models.Interfaces;

    public class Loan : ILoan
    {
        public Loan(string id, decimal drawnAmmount, decimal interestRate, byte yearsToReturn, NumberFormatInfo numberFormat)
        {
            this.Id = id;
            this.DrawnAmount = drawnAmmount;
            this.InterestRate = interestRate;
            this.YearsToReturn = yearsToReturn;
            this.NumberFormat = numberFormat;
        }

        public Loan(decimal drawnAmmount, AccountType accountType, byte yearsToReturn, NumberFormatInfo numberFormat)
        {
            this.Id = Guid.NewGuid().ToString();
            this.DrawnAmount = drawnAmmount;
            this.InterestRate = CalculateInterestRate(accountType);
            this.YearsToReturn = yearsToReturn;
            this.NumberFormat = numberFormat;
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

            Console.WriteLine(accountType.ToString());

            switch (accountType.ToString())
            {
                case AccountTypeConstant.REGULAR_ACCOUNT_TYPE_NAME:
                    interestRate = 0.6m;
                    break;

                case AccountTypeConstant.BRONZE_ACCOUNT_TYPE_NAME:
                    interestRate = 0.5m;
                    break;

                case AccountTypeConstant.GOLD_ACCOUNT_TYPE_NAME:
                    interestRate = 0.3m;
                    break;

                case AccountTypeConstant.PLATINUM_ACCOUNT_TYPE_NAME:
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
