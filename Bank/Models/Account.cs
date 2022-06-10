namespace EvilBank.Models
{
    using System.Collections.Generic;

    using EvilBank.Models.AccountTypes;

    public class Account
    {
        public Account(string firstName, string lastName, decimal balance)
        {
            this.Owner = new Client(firstName, lastName);
            this.Id = Owner.Id;
            this.Balance = balance;
            this.Loans = new List<Loan>();
            this.AccountType = new Regular(this);
            this.AccountType.StateChangeCheck();
        }

        public Account(Client client, decimal balance)
        {
            this.Owner = client;
            this.Id = client.Id;
            this.Balance = balance;
            this.Loans = new List<Loan>();
            this.AccountType = new Regular(this);
        }

        public Client Owner { get; set; }

        public string Id { get; set; }

        public string AccountHolder => this.Owner.FirstName + ' ' + this.Owner.LastName;

        public decimal Balance { get; set; }

        public AccountType AccountType { get; set; }

        public string AccountTypeName => this.AccountType.GetType().Name;

        public List<Loan> Loans { get; set; }

        public void AddMoney(decimal amount)
        {
            this.AccountType.AddMoneyToAccount(amount);
        }

        public void DrawMoney(decimal amount)
        {
            this.AccountType.DrawMoneyFromAccount(amount);
        }
    }
}
