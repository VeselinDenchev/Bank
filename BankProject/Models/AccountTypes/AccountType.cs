namespace BankProject.Models.AccountTypes
{
    using BankProject.Models.Interfaces;

    public abstract class AccountType : IState
    {
        public AccountType(IAccount account)
        {
            Account = account;
            Balance = account.Balance;
        }

        public IAccount Account { get; set; }

        public decimal Balance { get; set; }

        public decimal LowerLimit { get; set; }

        public decimal UpperLimit { get; set; }

        public virtual void AddMoneyToAccount(decimal amount) => Account.Balance += amount;

        public virtual void DrawMoneyFromAccount(decimal amount) => Account.Balance -= amount;

        public abstract void StateChangeCheck();
    }
}
