namespace BankProject.Models
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    using BankProject.Constants;
    using BankProject.Models.AccountTypes;
    using BankProject.Models.Interfaces;

    public class Account : IAccount
    {
        public Account(string firstName, string lastName, string id, decimal balance, List<ILoan> loans, NumberFormatInfo numberFormat)
            : this(firstName, lastName, balance, numberFormat)
        {
            this.Id = id;
            this.Loans = loans;
        }

        public Account(string firstName, string lastName, decimal balance, NumberFormatInfo numberFormat)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = Guid.NewGuid().ToString();
            this.Balance = balance;
            this.Loans = new List<ILoan>();
            this.AccountType = new RegularAccountType(this);
            this.AccountType.StateChangeCheck();
            this.NumberFormat = numberFormat;
        }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Id { get; init; }

        public string AccountHolderFullName => this.FirstName + ' ' + this.LastName;

        public decimal Balance { get; set; }

        public AccountType AccountType { get; set; }

        public List<ILoan> Loans { get; set; }

        private NumberFormatInfo NumberFormat { get; init; }

        public void AddMoney(decimal amount) => AccountType.AddMoneyToAccount(amount);

        public void DrawMoney(decimal amount) => AccountType.DrawMoneyFromAccount(amount);

        public void DrawLoan(ILoan loan)
        {
            this.AddMoney(loan.DrawnAmount);
            this.Loans.Add(loan);
        }

        public void ReturnLoan(ILoan loan)
        {
            this.DrawMoney(loan.AmountToReturn);
            this.Loans.Remove(loan);
        }

        public override string ToString()
        {
            StringBuilder accountStringBuilder = new StringBuilder();
            accountStringBuilder.AppendLine(string.Format(this.NumberFormat, StringConstant.ACCOUNT_STRING, this.AccountHolderFullName, this.Id,
                                                            this.Balance, this.AccountType.ToString()));

            bool hasLoans = this.Loans.Count > 0;
            if (hasLoans)
            {
                accountStringBuilder.AppendLine(StringConstant.LOANS_TO_BE_RETURNED_STRING);
                accountStringBuilder.AppendLine(StringConstant.LOAN_SEPERATOR);

                foreach (Loan loan in this.Loans)
                {
                    
                    accountStringBuilder.AppendLine(loan.ToString());
                    accountStringBuilder.AppendLine(StringConstant.LOAN_SEPERATOR);
                }
            }

            string accountString = accountStringBuilder.ToString().TrimEnd();

            return accountString;
        }
    }
}
