namespace BankProject.Models
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    using BankProject.Commands;
    using BankProject.Models.AccountTypes;
    using BankProject.Singletons;

    public class Account
    {
        public Account(string firstName, string lastName, decimal balance)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = Guid.NewGuid().ToString();
            this.Balance = balance;
            this.Loans = new List<Loan>();
            this.AccountType = new Regular(this);
            this.AccountType.StateChangeCheck();
            this.NumberFormat = NumberFormatSingleton.Instance;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Id { get; set; }

        public string AccountHolderFullName => this.FirstName + ' ' + this.LastName;

        public decimal Balance { get; set; }

        public AccountType AccountType { get; set; }

        public string AccountTypeName => AccountType.GetType().Name;

        public List<Loan> Loans { get; set; }

        private NumberFormatInfo NumberFormat { get; init; }

        public void AddMoney(decimal amount)
        {
            AccountType.AddMoneyToAccount(amount);
        }

        public void DrawMoney(decimal amount)
        {
            AccountType.DrawMoneyFromAccount(amount);
        }

        public void DrawLoan(Loan loan)
        {
            this.AddMoney(loan.DrawnAmount);
            this.Loans.Add(loan);
        }

        public void ReturnLoan(Loan loan)
        {
            this.DrawMoney(loan.AmountToReturn);
            this.Loans.Remove(loan);
        }

        public override string ToString()
        {
            StringBuilder accountStringBuilder = new StringBuilder();
            accountStringBuilder.AppendLine($"Fullname: {this.AccountHolderFullName}");
            accountStringBuilder.AppendLine($"ID: {this.Id}");
            accountStringBuilder.AppendLine(string.Format(this.NumberFormat, "Balance: {0:C}", this.Balance));
            accountStringBuilder.AppendLine($"Account type: {this.AccountTypeName}");

            bool hasLoans = this.Loans.Count > 0;
            if (hasLoans)
            {
                accountStringBuilder.AppendLine($"Loans to be returned:");
                accountStringBuilder.AppendLine("\t---------------------------------------------------------------------------------");

                foreach (Loan loan in this.Loans)
                {
                    
                    accountStringBuilder.AppendLine(loan.ToString());
                    accountStringBuilder.AppendLine("\t---------------------------------------------------------------------------------");
                }
            }

            string accountString = accountStringBuilder.ToString().TrimEnd();

            return accountString;
        }
    }
}
