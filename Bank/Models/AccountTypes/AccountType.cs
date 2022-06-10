namespace EvilBank.Models.AccountTypes
{
    public abstract class AccountType
    {
        private readonly double interestRate;

        public AccountType(Account account)
        {
            this.Account = account;
            this.Balance = account.Balance;
        }

        public Account Account { get; set; }

        public decimal Balance { get; set; }

        public decimal LowerLimit { get; set; }

        public decimal UpperLimit { get; set; }

        public virtual void AddMoneyToAccount(decimal amount) => this.Account.Balance += amount;

        public virtual void DrawMoneyFromAccount(decimal amount) => this.Account.Balance -= amount;

        public abstract void StateChangeCheck();
    }
}
