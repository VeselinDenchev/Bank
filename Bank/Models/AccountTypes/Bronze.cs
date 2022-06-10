namespace EvilBank.Models.AccountTypes
{
    internal class Bronze : AccountType
    {
        public Bronze(AccountType accountType)
            : this(accountType.Account)
        {
        }

        public Bronze(Account account) : base(account)
        {
            base.Account = account;
            this.LowerLimit = 100_000;
            this.UpperLimit = 200_000;
            //this.StateChangeCheck();
        }

        public override void AddMoneyToAccount(decimal amount)
        {
            base.AddMoneyToAccount(amount);
            this.StateChangeCheck();
        }

        public override void DrawMoneyFromAccount(decimal amount)
        {
            base.DrawMoneyFromAccount(amount);
            this.StateChangeCheck();
        }

        public override void StateChangeCheck()
        {
            if (base.Account.Balance < this.LowerLimit)
            {
                base.Account.AccountType = new Regular(this);
                base.Account.AccountType.StateChangeCheck();
            }
            else if (base.Account.Balance > this.UpperLimit)
            {
                base.Account.AccountType = new Gold(this);
                base.Account.AccountType.StateChangeCheck();
            }
        }
    }
}
