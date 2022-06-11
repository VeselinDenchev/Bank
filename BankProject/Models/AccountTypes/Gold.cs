namespace BankProject.Models.AccountTypes
{
    internal class Gold : AccountType
    {
        public Gold(AccountType accountType)
            : this(accountType.Account)
        {
        }

        public Gold(Account account) : base(account)
        {
            Account = account;
            LowerLimit = 200_000;
            UpperLimit = 500_000;
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
                Account.AccountType = new Bronze(this);
                Account.AccountType.StateChangeCheck();
            }
            else if (Account.Balance > UpperLimit)
            {
                Account.AccountType = new Platinum(this);
                Account.AccountType.StateChangeCheck();
            }
        }
    }
}
