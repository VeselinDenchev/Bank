namespace BankProject.Models.AccountTypes
{
    using BankProject.Models;

    internal class Regular : AccountType
    {
        public Regular(AccountType accountType)
            : this(accountType.Account)
        {
        }

        public Regular(Account account) : base(account)
        {
            Account = account;
            LowerLimit = 0;
            UpperLimit = 100_000;
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
            if (Account.Balance > UpperLimit)
            {
                Account.AccountType = new Bronze(this);
                Account.AccountType.StateChangeCheck();
            }
        }
    }
}
