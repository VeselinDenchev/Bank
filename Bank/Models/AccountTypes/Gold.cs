namespace EvilBank.Models.AccountTypes
{
    internal class Gold : AccountType
    {
        public Gold(AccountType accountType)
            : this(accountType.Account)
        {
        }

        public Gold(Account account) : base(account)
        {
            base.Account = account;
            this.LowerLimit = 200_000;
            this.UpperLimit = 500_000;
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
                base.Account.AccountType = new Bronze(this);
                base.Account.AccountType.StateChangeCheck();
            }
            else if (base.Account.Balance > this.UpperLimit)
            {
                base.Account.AccountType = new Platinum(this);
                base.Account.AccountType.StateChangeCheck();
            }
        }
    }
}
