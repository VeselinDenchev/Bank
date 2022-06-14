namespace BankProject.Models.AccountTypes
{
    using BankProject.Constants;
    using BankProject.Models.Interfaces;

    public class Regular : AccountType
    {
        public Regular(AccountType accountType)
            : this(accountType.Account)
        {
        }

        public Regular(IAccount account) 
            : base(account)
        {
            Account = account;
            LowerLimit = AccountTypeLimitConstant.REGULAR_ACCOUNT_TYPE_LOWER_LIMIT;
            UpperLimit = AccountTypeLimitConstant.REGULAR_ACCOUNT_TYPE_UPPER_LIMIT;
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
