namespace BankProject.Models.AccountTypes
{
    using BankProject.Models;

    internal class Platinum : AccountType
    {
        public Platinum(AccountType accountType)
            : this(accountType.Account)
        {
        }

        public Platinum(Account account) : base(account)
        {
            Account = account;
            LowerLimit = 500_000;
            UpperLimit = decimal.MaxValue;
            //this.StateChangeCheck();
        }

        public override void AddMoneyToAccount(decimal amount)
        {
            base.AddMoneyToAccount(amount);
            StateChangeCheck();
        }

        public override void DrawMoneyFromAccount(decimal amount)
        {
            base.DrawMoneyFromAccount(amount);
            StateChangeCheck();
        }

        public override void StateChangeCheck()
        {
            if (Account.Balance < LowerLimit)
            {
                Account.AccountType = new Gold(this);
                Account.AccountType.StateChangeCheck();
            }
        }
    }
}
