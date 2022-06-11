namespace BankProject.Models.AccountTypes
{
    internal class Bronze : AccountType
    {
        public Bronze(AccountType accountType)
            : this(accountType.Account)
        {
        }

        public Bronze(Account account) : base(account)
        {
            Account = account;
            LowerLimit = 100_000;
            UpperLimit = 200_000;
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
                Account.AccountType = new Regular(this);
                Account.AccountType.StateChangeCheck();
            }
            else if (Account.Balance > UpperLimit)
            {
                Account.AccountType = new Gold(this);
                Account.AccountType.StateChangeCheck();
            }
        }
    }
}
