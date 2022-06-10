namespace EvilBank.Models.AccountTypes
{
    internal class Platinum : AccountType
    {
        public Platinum(AccountType accountType)
            : this(accountType.Account)
        {
        }

        public Platinum(Account account) : base(account)
        {
            base.Account = account;
            this.LowerLimit = 500_000;
            this.UpperLimit = Decimal.MaxValue;
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
                base.Account.AccountType = new Gold(this);
                base.Account.AccountType.StateChangeCheck();
            }
        }
    }
}
