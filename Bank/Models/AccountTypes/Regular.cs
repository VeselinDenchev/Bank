
namespace EvilBank.Models.AccountTypes
{
    internal class Regular : AccountType
    {
        public Regular(AccountType accountType)
            : this(accountType.Account)
        {
        }

        public Regular(Account account) : base(account)
        {
            base.Account = account;
            this.LowerLimit = 0;
            this.UpperLimit = 100_000;
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
            if (base.Account.Balance > this.UpperLimit)
            {
                base.Account.AccountType = new Bronze(this);
                base.Account.AccountType.StateChangeCheck();
            }
        }
    }
}
