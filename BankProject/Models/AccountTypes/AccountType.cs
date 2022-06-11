namespace BankProject.Models.AccountTypes
{
    public abstract class AccountType
    {
        private readonly double interestRate;

        public AccountType(Account account)
        {
            Account = account;
            Balance = account.Balance;
        }

        public Account Account { get; set; }

        public decimal Balance { get; set; }

        public decimal LowerLimit { get; set; }

        public decimal UpperLimit { get; set; }

        public virtual void AddMoneyToAccount(decimal amount) => Account.Balance += amount;

        public virtual void DrawMoneyFromAccount(decimal amount) => Account.Balance -= amount;

        public abstract void StateChangeCheck();
    }
}
