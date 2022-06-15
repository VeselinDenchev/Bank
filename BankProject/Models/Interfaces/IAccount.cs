namespace BankProject.Models.Interfaces
{
    using BankProject.Models.AccountTypes;

    public interface IAccount : IIdentity<string>
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string AccountHolderFullName => this.FirstName + ' ' + this.LastName;

        public decimal Balance { get; set; }

        public AccountType AccountType { get; set; }

        public List<ILoan> Loans { get; set; }

        public void AddMoney(decimal amount);

        public void DrawMoney(decimal amount);

        public void DrawLoan(ILoan loan);

        public void ReturnLoan(ILoan loan);
    }
}