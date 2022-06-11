namespace BankProject.Models
{
    using System.Collections.Generic;
    using System.Text;

    using BankProject.Models.AccountTypes;

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
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Id { get; set; }

        public string AccountHolderFullName => this.FirstName + ' ' + this.LastName;

        public decimal Balance { get; set; }

        public AccountType AccountType { get; set; }

        public string AccountTypeName => AccountType.GetType().Name;

        public List<Loan> Loans { get; set; }

        public void AddMoney(decimal amount)
        {
            AccountType.AddMoneyToAccount(amount);
        }

        public void DrawMoney(decimal amount)
        {
            AccountType.DrawMoneyFromAccount(amount);
        }

        public override string ToString()
        {
            StringBuilder accountStringBuilder = new StringBuilder();
            accountStringBuilder.AppendLine($"Fullname: {this.AccountHolderFullName}");
            accountStringBuilder.AppendLine($"ID: {this.Id}");
            accountStringBuilder.AppendLine($"Balance: {this.Balance}");
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
